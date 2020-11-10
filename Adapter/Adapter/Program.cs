using System;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            User u = new User();
            StandartJack j = new StandartJack();
            u.Listen(j);
            Bluetooth b = new Bluetooth();
            IWire bWire = new BluetoothToWireAdapter(b);
            u.Listen(bWire);

            Console.Read();
        }
    }


    interface IWire
    {
        void Transfer();
    }


    class StandartJack : IWire
    {
        public void Transfer()
        {
            Console.WriteLine("Использется джек 6.3 мм");
        }
    }


    class User
    {
        public void Listen(IWire wire)
        {
            wire.Transfer();
        }
    }


    interface IWireless
    {
        void Send();
    }


    class Bluetooth : IWireless
    {
        public void Send()
        {
            Console.WriteLine("Использется Bluetooth");
        }
    }


    class BluetoothToWireAdapter : IWire
    {
        Bluetooth bluetooth;
        public BluetoothToWireAdapter(Bluetooth b)
        {
            bluetooth = b;
        }

        public void Transfer()
        {
            bluetooth.Send();
        }
    }
}
