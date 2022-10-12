using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// <summary>
// Open Close Principle
// A typical class is open for extension but closed for modification.
// </summary>
namespace DesignPatterns.SOLID
{
    public enum Color
    {
        Red, Green, Blue
    }

    public enum Size
    {
        Small, Medium, Large, Huge
    }

    public class Product
    {
        public string Name;
        public Color Color;
        public Size Size;

        public Product(string name, Color color, Size size)
        {
            Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
            Color = color;
            Size = size;
        }
    }

    public class ProductFilter
    {
        public IEnumerable<Product>? FilterBySize(IEnumerable<Product> products, Size size)
        {
            foreach (var product in products)
            {
                if(product.Size == size)
                    yield return product;
            }
        }

        public IEnumerable<Product>? FilterByColor(IEnumerable<Product> products, Color color)
        {
            foreach (var product in products)
            {
                if (product.Color == color)
                    yield return product;
            }
        }

        /// <summary>
        /// If this method has to be created later, even if it is much easier to modify something existing,
        /// we will not do it because we will violate the Open Close principle.
        /// According to this principle, the class is open for extension but closed for modification.
        /// </summary>
        public IEnumerable<Product>? FilterBySizeAndColor(IEnumerable<Product> products, Color color, Size size)
        {
            foreach (var product in products)
            {
                if (product.Color == color && product.Size == size)
                    yield return product;
            }
        }
    }

    /// <summary>
    /// If this method has to be created later, even if it is much easier to modify something existing,
    /// we will not do it because we will violate the Open Close principle.
    /// According to this principle, the class is open for extension but closed for modification.
    /// </summary>
    #region A better way to implement filtering without extending a class in a brutal way
    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }

    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }

    public class ColorSpecification : ISpecification<Product>
    {
        private readonly Color _color;

        public ColorSpecification(Color color)
        {
            _color = color;
        }

        public bool IsSatisfied(Product t)
        {
            return t.Color == _color;
        }
    }

    public class SizeSpecification : ISpecification<Product>
    {
        private readonly Size _size;

        public SizeSpecification(Size size)
        {
            _size = size;
        }

        public bool IsSatisfied(Product t)
        {
            return t.Size == _size;
        }
    }

    public class AndSpecification<T> : ISpecification<T>
    {
        private readonly ISpecification<T> _first, _second;

        public AndSpecification(ISpecification<T> first, ISpecification<T> second)
        {
            this._first = first;
            this._second = second;
        }

        public bool IsSatisfied(T t)
        {
            return _first.IsSatisfied(t) && _second.IsSatisfied(t);
        }
    }

    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
        {
            foreach (var item in items)
            {
                if (spec.IsSatisfied(item))
                    yield return item;
            }
        }
        // We did this because now, whenever we need to implement new filters,
        // we no longer need to come here to add something, but create a Specification Class that inherits ISpecification
    }
    #endregion
}
