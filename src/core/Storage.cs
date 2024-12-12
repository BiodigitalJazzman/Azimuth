namespace Azimuth
{
    public class Storage
    {
        private object[] elements;
        private int count;
        private const int DEFAULT_CAPACITY = 4;
        private Type elementType;

        public Storage(Type type, int capacity = DEFAULT_CAPACITY)
        {
            elementType = type;
            elements = new object[capacity];
            count = 0;
        }

        public object Add(object element)
        {
            if (!elementType.IsInstanceOfType(element))
            {
                throw new ArgumentException($"Element must be of type {elementType.Name}");
            }

            if (count >= elements.Length)
            {
                Array.Resize(ref elements, elements.Length * 2);
            }
            elements[count++] = element;
            return element;
        }

        public bool Remove(object element)
        {
            if (!elementType.IsInstanceOfType(element))
            {
                throw new ArgumentException($"Element must be of type {elementType.Name}");
            }

            int index = Array.IndexOf(elements, element, 0, count);
            if (index < 0) return false;

            Array.Copy(elements, index + 1, elements, index, count - index - 1);
            elements[--count] = null; // Clear the last element
            return true;
        }

        public object[] Get()
        {
            object[] result = Array.CreateInstance(elementType, count) as object[];
            Array.Copy(elements, result, count);
            return result;
        }
    }
}