using static NIC_Singeltone.Program.Task2;

namespace NIC_Singeltone
{
    internal class Program
    {
        internal class Task2
        {

            public enum NICType
            {
                Ethernet,
                TokenRing
            }

            public class NIC
            {
                private static NIC instance = null;

                public string Manufacture { get; private set; }
                public string MACAddress { get; private set; }
                public NICType Type { get; private set; }

                private NIC(string manufacture, string macAddress, NICType type)
                {
                    this.Manufacture = manufacture;
                    this.MACAddress = macAddress;
                    this.Type = type;
                }

                public static NIC GetInstance(string manufacture, string macAddress, NICType type)
                {
                    if (instance == null)
                    {
                        instance = new NIC(manufacture, macAddress, type);

                    }
                    return instance;
                }

                public override string ToString()
                {
                    return $"NIC Info: \nManufacture: {Manufacture}\nMAC Address: {MACAddress}\nType: {Type}";
                }
            }



        }
        static void Main(string[] args)
        {
            NIC nic = NIC.GetInstance("a", "05", NICType.Ethernet);

            Console.WriteLine(nic.ToString());

            NIC anotherNic = NIC.GetInstance("A", "AB", NICType.TokenRing);

            Console.WriteLine(anotherNic.ToString());
        }
    }
}
