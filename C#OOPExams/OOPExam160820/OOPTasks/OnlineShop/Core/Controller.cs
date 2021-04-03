using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

using OnlineShop.Common.Enums;
using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private readonly ICollection<IComputer> computers;
        private readonly ICollection<IComponent> components;
        private readonly ICollection<IPeripheral> peripherals;

        public Controller()
        {
            computers = new List<IComputer>();
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public string AddComponent(int computerId, int id,
            string componentType, string manufacturer,
            string model, decimal price, double overallPerformance,
            int generation)
        {
            CheckIfComponentAlreadyExist(id);
            IComponent component = CreateComponent(id, componentType,
                manufacturer, model, price, 
                overallPerformance, generation);

            CheckIfComputerExist(computerId);
            IComputer computer = GetComputerById(computerId);
            computer.AddComponent(component);

            components.Add(component);

            return string.Format(SuccessMessages
                .AddedComponent,component.GetType().Name,
                component.Id,computerId);
        }

        public string AddComputer(string computerType, int id,
            string manufacturer, string model, decimal price)
        {
            CheckIfComputerAlreadyExist(id);
            IComputer computer = CreateComputer(computerType, id,
                manufacturer, model, price);

            computers.Add(computer);

            return string.Format(SuccessMessages
                .AddedComputer, computer.Id);
        }

        public string AddPeripheral(int computerId, int id,
            string peripheralType, string manufacturer,
            string model, decimal price, double overallPerformance,
            string connectionType)
        {
            CheckIfPeripheralAlreadyExist(id);
            IPeripheral peripheral = CreatePeripheral(id, peripheralType,
                manufacturer, model, price,
                overallPerformance, connectionType);

            CheckIfComputerExist(computerId);
            IComputer computer = GetComputerById(computerId);

            computer.AddPeripheral(peripheral);
            peripherals.Add(peripheral);

            return string.Format(SuccessMessages
                .AddedPeripheral, peripheral.GetType().Name,
                peripheral.Id, computerId);
        }


        public string BuyBest(decimal budget)
        {
            var sorted = computers
                 .OrderByDescending(x => x.OverallPerformance)
                 .Where(x => x.Price <= budget).ToList();

            if(sorted.Count==0)
            {
                throw new ArgumentException
                    (string.Format(ExceptionMessages
                    .CanNotBuyComputer, budget));
            }

            IComputer computer = sorted.First();
            computers.Remove(computer);

            return computer.ToString();
        }

        public string BuyComputer(int id)
        {
            CheckIfComputerExist(id);
            IComputer computer = GetComputerById(id);

            computers.Remove(computer);

            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            CheckIfComputerExist(id);
            IComputer computer = GetComputerById(id);

            return computer.ToString();
        }

        public string RemoveComponent(string componentType,
            int computerId)
        {
            CheckIfComputerExist(computerId);
            IComputer computer = GetComputerById(computerId);

            IComponent component 
                = computer.RemoveComponent(componentType);
            components.Remove(component);

            return string.Format(SuccessMessages
                .RemovedComponent, componentType, component.Id);
        }

        public string RemovePeripheral(string peripheralType,
            int computerId)
        {
            CheckIfComputerExist(computerId);
            IComputer computer = GetComputerById(computerId);

            IPeripheral peripheral
               = computer.RemovePeripheral(peripheralType);
            peripherals.Remove(peripheral);

            return string.Format(SuccessMessages
                .RemovedPeripheral, peripheralType, peripheral.Id);
        }



        private IComputer GetComputerById(int computerId)
        {
            return computers
                 .FirstOrDefault(x => x.Id == computerId);
        }

        private void CheckIfComputerAlreadyExist(int id)
        {
            IComputer computer = computers
                .FirstOrDefault(x => x.Id == id);
            if (computer != null)
            {
                throw new ArgumentException
                    (ExceptionMessages.ExistingComputerId);
            }
        }

        private void CheckIfComputerExist(int id)
        {
            IComputer computer = computers
                .FirstOrDefault(x => x.Id == id);
            if (computer == null)
            {
                throw new ArgumentException
                    (ExceptionMessages.NotExistingComputerId);
            }
        }

        private IComputer CreateComputer(string computerType, int id,
           string manufacturer, string model, decimal price)
        {
            Type type = GetDefaultType(computerType);

            if (type == null)
            {
                throw new ArgumentException
                    (ExceptionMessages.InvalidComputerType);
            }

            IComputer computer = null;
            if (computerType == ComputerType.DesktopComputer.ToString())
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            if (computerType == ComputerType.Laptop.ToString())
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            return computer;
        }

        private IComponent CreateComponent(int id, string componentType,
            string manufacturer, string model,
            decimal price, double overallPerformance,
            int generation)
        {
            Type type = GetDefaultType(componentType);
            if (type == null)
            {
                throw new ArgumentException
                    (ExceptionMessages.InvalidComponentType);
            }

            IComponent component = null;
            if (componentType
                == ComponentType.CentralProcessingUnit.ToString())
            {
                component = new CentralProcessingUnit(id, manufacturer,
                    model, price, overallPerformance, generation);
            }
            if (componentType
               == ComponentType.Motherboard.ToString())
            {
                component = new Motherboard(id, manufacturer,
                    model, price, overallPerformance, generation);
            }
            if (componentType
               == ComponentType.PowerSupply.ToString())
            {
                component = new PowerSupply(id, manufacturer,
                    model, price, overallPerformance, generation);
            }
            if (componentType
                == ComponentType.RandomAccessMemory.ToString())
            {
                component = new RandomAccessMemory(id, manufacturer,
                    model, price, overallPerformance, generation);
            }
            if (componentType
               == ComponentType.SolidStateDrive.ToString())
            {
                component = new SolidStateDrive(id, manufacturer,
                    model, price, overallPerformance, generation);
            }
            if (componentType
                == ComponentType.VideoCard.ToString())
            {
                component = new VideoCard(id, manufacturer,
                    model, price, overallPerformance, generation);
            }

            return component;
        }

        private void CheckIfComponentAlreadyExist(int id)
        {
            IComponent component = components
                .FirstOrDefault(x => x.Id == id);
            if (component != null)
            {
                throw new ArgumentException
                    (ExceptionMessages.ExistingComponentId);
            }
        }

        private IPeripheral CreatePeripheral(int id, 
            string peripheralType, string manufacturer, 
            string model, decimal price, 
            double overallPerformance, string connectionType)
        {
            Type type = GetDefaultType(peripheralType);
            if (type == null)
            {
                throw new ArgumentException
                    (ExceptionMessages.InvalidPeripheralType);
            }

            IPeripheral peripheral = null;
            if (peripheralType
                == PeripheralType.Headset.ToString())
            {
                peripheral = new Headset(id, manufacturer,
                    model, price, overallPerformance, connectionType);
            }
            if (peripheralType
                == PeripheralType.Keyboard.ToString())
            {
                peripheral = new Keyboard(id, manufacturer,
                    model, price, overallPerformance, connectionType);
            }
            if (peripheralType
                == PeripheralType.Monitor.ToString())
            {
                peripheral = new Monitor(id, manufacturer,
                    model, price, overallPerformance, connectionType);
            }
            if (peripheralType
               == PeripheralType.Mouse.ToString())
            {
                peripheral = new Mouse(id, manufacturer,
                    model, price, overallPerformance, connectionType);
            }

            return peripheral;
        }

        private void CheckIfPeripheralAlreadyExist(int id)
        {
            IPeripheral peripheral = peripherals
                .FirstOrDefault(x => x.Id == id);
            if (peripheral != null)
            {
                throw new ArgumentException
                    (ExceptionMessages.ExistingPeripheralId);
            }
        }

        private Type GetDefaultType(string typeName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            Type type = asm.GetTypes()
                .FirstOrDefault(t => t.Name == typeName);
            return type;
        }
    }
}
