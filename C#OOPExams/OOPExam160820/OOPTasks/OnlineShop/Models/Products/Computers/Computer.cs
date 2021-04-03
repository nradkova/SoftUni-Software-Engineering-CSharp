using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private readonly ICollection<IComponent> components;
        private readonly ICollection<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer,
            string model, decimal price,
            double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components
            => (IReadOnlyCollection<IComponent>)components;

        public IReadOnlyCollection<IPeripheral> Peripherals
             => (IReadOnlyCollection<IPeripheral>)peripherals;

        public override decimal Price
            => base.Price + components.Sum(x => x.Price)
            + peripherals.Sum(x => x.Price);
        public override double OverallPerformance
            => base.OverallPerformance
            + (components.Count == 0
            ? 0
            :components.Average(x => x.OverallPerformance));

        public void AddComponent(IComponent component)
        {
            string componentType = component.GetType().Name;
            if (components.Any(x => x.GetType().Name == componentType))
            {
                throw new ArgumentException(string.Format
                    ( ExceptionMessages
                    .ExistingComponent,componentType,
                    this.GetType().Name,this.Id));
             }

            components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            string peripheralType = peripheral.GetType().Name;
            if (peripherals.Any(x => x.GetType().Name == peripheralType))
            {
                throw new ArgumentException(string.Format
                    (ExceptionMessages
                    .ExistingPeripheral, peripheralType,
                    this.GetType().Name, this.Id));
            }

            peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            IComponent component = components
                .FirstOrDefault(x => x.GetType().Name == componentType);
            if (component==null)
            {
                throw new ArgumentException(string.Format(
                    ExceptionMessages.NotExistingComponent,
                    componentType, this.GetType().Name, this.Id));
            }

            components.Remove(component);
            return component;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            IPeripheral peripheral = peripherals
               .FirstOrDefault(x => x.GetType().Name == peripheralType);
            if (peripheral == null)
            {
                throw new ArgumentException(string.Format(
                    ExceptionMessages.NotExistingPeripheral,
                    peripheralType, this.GetType().Name, this.Id));
            }

            peripherals.Remove(peripheral);
            return peripheral;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());

            sb.AppendLine(" "+string.Format(SuccessMessages
                .ComputerComponentsToString, components.Count));

            foreach (var component in components)
            {
                sb.AppendLine("  "+component.ToString());
            }

            double averagePeripheralsPerformance = 0;
            if (peripherals.Count > 0)
            {
               averagePeripheralsPerformance
                    = peripherals.Average(x => x.OverallPerformance);
            }

            sb.AppendLine(" "+string.Format(SuccessMessages
               .ComputerPeripheralsToString,
               peripherals.Count,
               Math.Round( averagePeripheralsPerformance,2)));

            foreach (var peripheral in peripherals)
            {
                sb.AppendLine("  "+peripheral.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
