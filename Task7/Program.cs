using System.IO;


namespace Task7
{
    internal class Program
    {
        #region point3D
        class point3D
        {
            public int x { get; set; }
            public int y { get; set; }
            public int z { get; set; }
            public point3D(int x , int y , int z )
            {
                this.x = x;
                this.y = y;
                this.z = z;

            }
            public point3D(int x,int y):this(x,y,0)
            {

            }
            public point3D(int x) : this(x, 0, 0)
            {

            }
            public point3D() : this(0,0, 0)
            {

            }
            public override string ToString()
            {
                return $"point3D({x},{y},{z})";
            }
            public static bool operator ==(point3D p1,point3D p2)
            {
                if (p1 is point3D&&p2 is point3D)
                {
                    return p1.x==p2.x&&p1.y==p2.y&&p1.z==p2.z;
                }
                return false;
            }
            public static bool operator !=(point3D p1, point3D p2)
            {
                if (p1 is point3D && p2 is point3D)
                {
                    return !(p1.x == p2.x && p1.y == p2.y && p1.z == p2.z);
                }
                return false;
            }
        }
        #endregion
        private static point3D GetPointFromUser(string pointName)
        {
            point3D point3D = new point3D();
            int x, y, z;
            string arr;
            Console.WriteLine($"please enter the coordinates for {pointName} as x,y,z ");
            StreamWriter stream = File.AppendText("Error Nassages");
           
               arr  =(Console.ReadLine());
            try
            {
                string[] a = arr.Split(',');
        
                if (a.Length == 3)
                {
                   
                 
                   point3D.x = int.Parse(a[0]);
                    point3D.y = int.Parse(a[1]);

                    // int.TryParse(a[1],out point3D.y);
                   point3D.z = Convert.ToInt32(a[2]);



                }
                else
                {
                    stream.WriteLine("pointinput must be integer and 3number only like(10,2,5)at {DateTime.Now}: {ex.Message}");
        
                }
            }
            catch (Exception)
            {
        
               
        
                stream.WriteLine("pointinput must be integer like(10,2,5) at {DateTime.Now}: {ex.Message}");
               
            }
        
            finally
            {
                stream.Close();
            }

            return point3D;
        }
        
        static void Main(string[] args)
        {
            point3D p1 = GetPointFromUser("p1");
            point3D p2 = GetPointFromUser("p2");

            Console.WriteLine(p1);
            Console.WriteLine(p2);
            if (p1 == p2)
            {
                Console.WriteLine("P1 is equal to P2");
            }
            else
            {
                Console.WriteLine("P1 is not equal to P2");
            }

        }
    }
}