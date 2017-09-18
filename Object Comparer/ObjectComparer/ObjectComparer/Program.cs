using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace ObjectComparer
{
    class Program
    {
        static void Main(string[] args)
        {
                Employee employee1 = new Employee();
                employee1.EmployeeID = 10;
                employee1.EmployeeName = "test1";
                employee1.ContactAddress = new Address();
                employee1.ContactAddress.Address1 = "address1";
                employee1.ContactAddress.City = "city";

                Employee employee2 = DeepClone<Employee>(employee1);
                employee2.EmployeeID = 20;
                employee2.ContactAddress.Address1 = "address2";

                CompareHelper.CompareObjects(employee1, employee2, new string[] { });

                Console.ReadLine();
            }

            public static T DeepClone<T>(T a)
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, a);
                    stream.Position = 0;
                    return (T)formatter.Deserialize(stream);
                }
            }
        }

        [Serializable]
        public class Employee
        {
            private int employeeID;
            private string employeeName;
            private Address contactAddress;

            public int EmployeeID
            {
                set { employeeID = value; }
                get { return employeeID; }
            }
            public string EmployeeName
            {
                set { employeeName = value; }
                get { return employeeName; }
            }
            public Address ContactAddress
            {
                set { contactAddress = value; }
                get { return contactAddress; }
            }
        }
        [Serializable]
        public class Address
        {
            private string address1;
            private string city;

            public string Address1
            {
                set { address1 = value; }
                get { return address1; }
            }

            public string City
            {
                set { city = value; }
                get { return city; }
            }
        }
    }
