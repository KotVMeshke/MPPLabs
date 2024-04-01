using FakerLab.Generators;
using FakerLab.Generators.CollectionsGenerators;
using FakerLab.Generators.StringGenerators;
using FakerLab.Generators.SystemObjectsGenerators;
using FakerLab.Generators.ValueTypesGenrators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FakerLab.FakerLabClass
{
    public class Faker
    {
        private readonly Dictionary<Type, Type> _generators = new()
        {
            { typeof(int), typeof(IntGenerator) },{ typeof(string), typeof(StringGenerator) },
            { typeof(List<>), typeof(ListGenerator<,>) },{ typeof(decimal), typeof(DecimalGenerator) },
            { typeof(double), typeof(DoubleGenerator) },{ typeof(float), typeof(FloatGenerator) },
            { typeof(byte), typeof(ByteGenerator) },{ typeof(long), typeof(LongGenerator) },
            { typeof(short), typeof(ShortGenerator) },{ typeof(char), typeof(CharGenerator) },
            { typeof(DateTime), typeof(DateTimeGenerator) },
        };

        private readonly HashSet<Type> _generated = new HashSet<Type>();

        public Faker()
        {

        }

        public T? Create<T>()
        {
            var type = typeof(T);
            return (T?)Generate(type);
        }

        public object? Generate(Type type)
        {
            if (_generated.Remove(type))
            {
                return null;
            }

            _generated.Add(type);
            object? instance = null;
            try
            {
                instance = GetInstance(type);
                GenerateFields(instance);
                GenerateProperties(instance);
            }
            catch(InvalidOperationException)
            {
                Console.WriteLine($"Class: {type.Name} from {type.Namespace} is abstract");
            }
            finally
            {
                _generated.Remove(type);

            }

            return instance;


        }

        private object? GetInstance(Type type)
        {
            if (type.IsAbstract)
            {
                throw new InvalidOperationException();
            }

            var classConstructors = type.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            var mostParametersConstructor = classConstructors.OrderByDescending(c => c.GetParameters().Length).FirstOrDefault();

            if (mostParametersConstructor is null)
                return Activator.CreateInstance(type)!;

            var parameters = mostParametersConstructor.GetParameters();
            var constructorArgs = new object?[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                var parameter = parameters[i];
                var parameterType = parameter.ParameterType;
                constructorArgs[i] = GenerateValue(parameterType);
            }

            try
            {
                return mostParametersConstructor.Invoke(constructorArgs);
            }
            catch (TargetInvocationException)
            {
                return null;
            }


        }

        private void GenerateProperties(object? instance)
        {
            var type = instance!.GetType();
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                var value = property.GetValue(instance);

                if (HasPublicSetter(property) && (value is null || IsGenerated(value)))
                {
                    var generated = GenerateValue(property.PropertyType);
                    property.SetValue(instance, generated);
                }
            }
        }

        private static bool HasPublicSetter(PropertyInfo property)
        {
            var setter = property.GetSetMethod();
            return setter is not null && setter.IsPublic;
        }

        private void GenerateFields(object? instance)
        {
           var type = instance!.GetType();
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);

            foreach (var field in fields)
            {
                var value = field.GetValue(instance);
                if (value is null || IsGenerated(value))
                {
                    var generated = GenerateValue(field.FieldType);
                    field.SetValue(instance, generated);
                }
            }
        }

        private static bool IsGenerated(object value)
        {
            var type = value.GetType();
            return type.IsValueType && value.Equals(Activator.CreateInstance(type));
        }

        private object? GenerateValue(Type type)
        {
            var tempType = type;

            if (type.IsGenericType)
            {
                type = type.GetGenericTypeDefinition();
            }

            if (_generators.TryGetValue(type, out Type? generatorType))
            {
                if (generatorType.IsGenericType)
                {
                    return GenerateGenericType(tempType, generatorType);
                }
                else
                {
                    var generator = Activator.CreateInstance(generatorType);
                    var generateMethod = generatorType.GetMethod("GenerateValue")!;
                    return generateMethod.Invoke(generator, null);
                }
            }

            if (type.IsGenericType)
            {
                return null;
            }

            return Generate(type);
        }

        private object? GenerateGenericType(Type parametrType, Type generatorType)
        {
            var parametrArguments = parametrType.GetGenericArguments().ToList();
            var size = generatorType.GetGenericArguments().Length - parametrArguments.Count;

            for (int i = 0; i < size; i++)
            {
                parametrArguments.Add(_generators[parametrArguments[i]]);
            }

            var generatorFinalType = generatorType.MakeGenericType(parametrArguments.ToArray());
            var generator = Activator.CreateInstance(generatorFinalType);
            var method = generatorFinalType.GetMethod("GenerateValue")!;

            return method.Invoke(generator, null);
        }
    }
}
