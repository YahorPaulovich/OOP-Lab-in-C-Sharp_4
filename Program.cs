using System;

namespace ClassComposition //Вариант 14 
{//No 5 Наследование, полиморфизм, абстрактные классы и интерфейсы

    /*Задание 
      1) Определить иерархию и композицию классов (в соответствии с вариантом), 
         реализовать классы. Если необходимо расширьте по своему усмотрению иерархию для выполнения всех пунктов л.р. 
         Каждый класс должен иметь отражающее смысл название и информативный состав. 
         При кодировании должны быть использованы соглашения об оформлении кода code convention. 
         В одном из классов переопределите все методы, унаследованные от Object. 

      2) В проекте должны быть интерфейсы и абстрактный класс(ы). 
         Использовать виртуальные методы и переопределение.

      3) Сделайте один из классов герметизированным (бесплодным). 

      4) Добавьте в интерфейсы или интерфейс + абстрактный класс одноименные методы. 
         Дайте в наследуемом классе им разную реализацию и вызовите эти методы. 

      5) Написать демонстрационную программу, в которой создаются объекты различных классов. 
         Поработать с объектами через ссылки на абстрактные классы и интерфейсы. 
         В этом случае для идентификации типов объектов использовать операторы is или as. 

      6) Во всех классах (иерархии) переопределить метод ToString(), который выводит информацию о типе объекта и его текущих значениях. 
         Создайте дополнительный класс Printer c полиморфным методом iAmPrinting( SomeAbstractClassorInterface someobj). 
         Формальным параметром метода должна быть ссылка на абстрактный класс или наиболее общий интерфейс в вашей иерархии классов. 
         В методе iAmPrinting определите тип объекта и вызовите ToString(). 
         В демонстрационной программе создайте массив, содержащий ссылки на разнотипные объекты ваших классов по иерархии, 
         а также объект класса Printer и последовательно вызовите его метод iAmPrinting со всеми ссылками в качестве аргументов.*/

    /*Млекопитающие, Птицы, Животное, Рыба, Лев, Сова,Тигр, Крокодил, Акула, Попугай.*/
    class Program
    {
        public interface IOrganism
        {
            void GetInfo();
            public abstract string ToString();
            public double GetWeight();           
        }

        public abstract class Animals //Животные
        {
            public new abstract string ToString();

            public string Name;
            public float BodyLength;
            public double Weight;

            public Animals() { Name = "disenabled"; BodyLength = 0; Weight = 0; }

            public Animals(string Name)
            {
                this.Name = Name;
                BodyLength = 0;
                Weight = 0;
            }

            public Animals(string Name, float BodyLength)
            {
                this.Name = Name;
                this.BodyLength = BodyLength;
                Weight = 0;
            }
            public Animals(string Name, float BodyLength, double Weight)
            {
                this.Name = Name;
                this.BodyLength = BodyLength;
                this.Weight = Weight;
            }
            public virtual double GetWeight()
            {
                return Weight;
            }

            public static ref double Find(double Weight, Animals[] A)
            {
                for (int i = 0; i < A.Length; i++)
                {
                    if (A[i].Weight == Weight)
                    {
                        return ref A[i].Weight; // возвращается ссылка на адрес, а не само значение
                    }
                }
                throw new IndexOutOfRangeException("Животное с таким весом не найдено!");
            }
        }

        public class Mammals : Animals, IOrganism //Млекопитающие
        {
            public DateTime Age { get; private set; }

            public Mammals(string Name) : base(Name)
            {
                BodyLength = 0;
                Weight = 0;
                Age = DateTime.Now;
            }
            public Mammals(string Name, float BodyLength) : base(Name)
            {
                this.BodyLength = BodyLength;
                Weight = 0;
                Age = DateTime.Now;
            }
            public Mammals(string Name, float BodyLength, double Weight) : base(Name)
            {
                this.BodyLength = BodyLength;
                this.Weight = Weight;
                Age = DateTime.Now;
            }

            public override double GetWeight()
            {
                return Weight;
            }

            public void GetInfo()
            {
                Console.WriteLine($"Название животного {Name} Длина тела: {BodyLength} Вес: {Weight} Возраст: {Age}");
            }
          
            public override string ToString()
            {
                return string.Format("Млекопитающее: {0}; Длина тела = {1}; Вес = {2}.", Name, BodyLength, Weight);
            }
        }

        sealed class Crocodile //Крокодил
        {
            public string Name;
            public float BodyLength;
            public double Weight;

            public Crocodile() { Name = "disenabled"; BodyLength = 0; Weight = 0; }
            public Crocodile(string Name)
            {
                this.Name = Name;
                BodyLength = 0;
                Weight = 0;
            }
            public Crocodile(string Name, float BodyLength)
            {
                this.Name = Name;
                this.BodyLength = BodyLength;
                Weight = 0;
            }
            public Crocodile(string Name, float BodyLength, double Weight)
            {
                this.Name = Name;
                this.BodyLength = BodyLength;
                this.Weight = Weight;
            }

            public override string ToString()
            {
                return string.Format("Рептилия: {0}; Длина тела = {1}; Вес = {2}.", Name, BodyLength, Weight);
            }
            public override int GetHashCode()
            {
                return Name.GetHashCode();
            }
            public override bool Equals(Object obj)
            {
                if (obj == null || GetType() != obj.GetType()) return false;
                Crocodile temp = (Crocodile)obj;
                return Name == temp.Name &&
                BodyLength == temp.BodyLength &&
                Weight == temp.Weight;
            }
            public new static bool ReferenceEquals(Object objA, Object objB)
            {
                return objA == objB;
            }

            //Finalize()

            //GetType()

            //Clone()        
        }

        public class Birds : Animals, IOrganism //Птицы
        {
            public Birds(string Name) : base(Name)
            {
                BodyLength = 0;
                Weight = 0;
            }
            public Birds(string Name, float BodyLength) : base(Name)
            {
                this.BodyLength = BodyLength;
                Weight = 0;
            }
            public Birds(string Name, float BodyLength, double Weight) : base(Name)
            {
                this.BodyLength = BodyLength;
                this.Weight = Weight;
            }
            public override double GetWeight()
            {
                return Weight;
            }
            public void GetInfo()
            {
                Console.WriteLine($"Название животного {Name} Длина тела: {BodyLength} Вес: {Weight}");
            }

            public override string ToString()
            {
                return string.Format("Птица: {0}; Длина тела = {1}; Вес = {2}.", Name, BodyLength, Weight);
            }
        }

        public class Fish : Animals, IOrganism //Рыбы
        {
            public Fish(string Name) : base(Name)
            {
                BodyLength = 0;
                Weight = 0;
            }
            public Fish(string Name, float BodyLength) : base(Name)
            {
                this.BodyLength = BodyLength;
                Weight = 0;
            }
            public Fish(string Name, float BodyLength, int Weight) : base(Name)
            {
                this.BodyLength = BodyLength;
                this.Weight = Weight;
            }
            public override double GetWeight()
            {
                return Weight;
            }
            public void GetInfo()
            {
                Console.WriteLine($"Название животного {Name} Длина тела: {BodyLength} Вес: {Weight}");
            }
            public override string ToString()
            {
                return string.Format("Рыба: {0}; Длина тела = {1}; Вес = {2}.", Name, BodyLength, Weight);
            }
        }
        static void Main(string[] args)
        {
            Animals[] animals = new Mammals[3];
            animals[0] = new Mammals("Лев", 2, 190);
            animals[1] = new Mammals("Львица", 2, 150);
            animals[2] = new Mammals("Львёнок", 1, 90);

            for (int i = 0; i < animals.Length; i++)
                Console.WriteLine(animals[i].ToString());

            Console.WriteLine();

            Animals[] birds = new Birds[2];
            birds[0] = new Birds("Сова", 1, 10);
            birds[1] = new Birds("Совушка", 1, 5);

            for (int i = 0; i < birds.Length; i++)
                Console.WriteLine(birds[i].ToString());

            Console.WriteLine();

            Animals[] fish = new Fish[1];
            fish[0] = new Fish("Акула", 3, 540);
            Console.WriteLine(fish[0].ToString());

            Console.WriteLine();

            Crocodile[] crocodile = new Crocodile[3];
            crocodile[0] = new Crocodile("Крокодил1", 7, 600);
            crocodile[1] = new Crocodile("Крокодил2", 6, 500);
            crocodile[2] = new Crocodile("Крокодил3", 5, 400);

            for (int i = 0; i < crocodile.Length; i++)
                Console.WriteLine(crocodile[i].ToString());

            if (crocodile[0].BodyLength.Equals(crocodile[1].BodyLength))
            {
                Console.WriteLine($"Длина тела крокодила '{crocodile[0].Name}(с хэшем:{crocodile[0].GetHashCode()})' равна длине тела '{crocodile[1].Name}(с хэшем:{crocodile[1].GetHashCode()})'");
            }
            else Console.WriteLine($"Длина тела крокодила '{crocodile[0].Name}(с хэшем:{crocodile[0].GetHashCode()})' не равна длине тела '{crocodile[1].Name}(с хэшем:{crocodile[1].GetHashCode()})'");
            Console.WriteLine();

            int sum = 0;
            for (int i = 0; ; i++)
            {
                try
                {
                    object numbers = crocodile[i];
                    var n = numbers as Crocodile;
                    Console.WriteLine($"{n.Name};");
                    sum++;
                }
                catch
                {
                    Console.WriteLine($"'Крокодил{i + 1}' не является объектом Crocodile.");
                    break;
                }
            }
            Console.WriteLine($"\nВсего крокодилов = {sum}");

            Console.WriteLine($"\nВывод используя метод iAmPrinting() \n");
            string result = Convert.ToString(birds[0].ToString());
            Console.WriteLine(result.IAmPrinting());

            Console.WriteLine("\nПроверка, является ли переменная C типом float...");          
            Crocodile C = new Crocodile("AbstractCrocodile", 6,1);

            // проверка, является ли переменная C типом float
            if (C is float)
                Console.WriteLine("Переменная C имеет тип float");
            else
                Console.WriteLine("Переменная C не имеет тип float");

            // проверка, является ли C типом Crocodile
            Console.WriteLine("\nПроверка, является ли C типом Crocodile...");           
            if (C is Crocodile)
                Console.WriteLine("Переменная C имеет тип Crocodile");
            else
                Console.WriteLine("Переменная C не является типом Crocodile");

            Console.WriteLine("\nПопытка привести animalsA к типу Birds...");
            // объекты классов Mammals, Birds
            Animals animalsA = new Mammals("A");
            Birds birdB = new Birds("B", 2, 1);
           
            // в animals заносится результат приведения объекта animals
            birdB = animalsA as Birds;
            if (birdB == null)
                Console.WriteLine("Невозможно привести animalsA к типу Birds");
            else
                Console.WriteLine("Можно приводить animalsA к типу Birds");

            // еще одна попытка привести birdB к типу Animals, результат в animalsA
            Console.WriteLine("Еще одна попытка привести birdB к типу Animals, результат в animalsA...");
            animalsA = birdB as Animals;
            // вывод результата
            if (animalsA == null)
                Console.WriteLine("Невозможно привести birdB к типу Animals");
            else
                Console.WriteLine("Можно приводить birdB к типу Animals");
            Console.WriteLine();

            Console.WriteLine("Изменение объекта по ссылке на него...");
            Console.WriteLine(animals[1].ToString()); // 150
            ref double weightRef = ref Animals.Find(150, animals); // поиск веса 150 в массиве
            weightRef = 10000000; // замена 150 на 10000000
            Console.WriteLine(animals[1].ToString()); // 10000000

            Console.WriteLine("\nСоздание массива, содержащего ссылки на разнотипные объекты моих классов по иерархии...");
            Console.WriteLine("Вызов метода IAmPrinting со всеми ссылками в качестве аргументов...\n");

            Mammals BrownBear = new Mammals("Бурый медведь", 2, 500);
            Birds WhiteOwl = new Birds("Белая сова", 0.70f, 3);
            Fish WhiteShark = new Fish("Белая акула", 4.5f, 520);
            Crocodile CombedCrocodile = new Crocodile("Гребнистый крокодил", 5.2f, 1000);

            ref Mammals MammaRef = ref BrownBear;
            ref Birds BirdRef = ref WhiteOwl;
            ref Fish FishRef = ref WhiteShark;
            ref Crocodile CrocoRef = ref CombedCrocodile;

            object[] Refanimals = { MammaRef.ToString(), BirdRef.ToString(), FishRef.ToString(), CrocoRef };        
            foreach (var item in Refanimals)
            {
                string res = item.ToString();
                Console.WriteLine(res.IAmPrinting());
            }


            Console.ReadKey();    
        }      
    }
    public static class Printer
    {
        public static object IAmPrinting(this string mammals)
        {
            return mammals.ToString();
        }

        public static string ToStr(this string mammals)
        {
            return mammals.ToString();
        }       
    }
}
