using System;

namespace LearningDeligateLambda
{
    class Program
    {

        //Объявляем делигат 
        public delegate int Mydeligate(int x, int y);

        static int[] massiv = new int[3];

        public delegate void MytestDelegate(int x);
 
//         

        static void Sum_1(int x, int y)
        {
            Console.WriteLine(x+y);
        }

        static int Sum_2(int x, int y)
        {
            Console.WriteLine(x+y);
            return x+y;
        }

        static bool Sum_3(int x)
        {
            Console.WriteLine(x);
            return x > 0;
        }

        static int Sum_4(int x, int y)
        {
            return x+y;
        }

        
        static void Main(string[] args)
        {

            // Mydeligate mydeligate = new Mydeligate(Sum_1);
            // mydeligate+=Sum_2; //добавляем метод в делегат
            // mydeligate-=Sum_2; //удаляем метод из делигата
            // int a = mydeligate.Invoke(2,1); // отправляем делегат на выволнение.   
            // Console.WriteLine(a);

            //Шаблоны предикатов Action, Predicate, Func

            Action<int,int> action = Sum_1; //шаблон для Action для делигат. Не возвращает значение, но может принимать аргументы
                                            //public delegate void Action(int i, int y) = Action<int,int>
            action(5,7);

            Predicate<int> predicate = Sum_3; //шаблон Predicate для делигата
                                              //public delegate bool Predicate(int x) = Predicate<int>
              
            Console.WriteLine(predicate(2));  
            Func<int,int,int> myfunc = Sum_4; //шаблон Func
                                              //public deligate int Func(int x, int y) = Func<int,int,int> последний аргумент - тип возвращаемого значения.  
            
            if (myfunc != null) Console.WriteLine(myfunc(2,8)); // myfunc != null - проверяем, есть ли в делигате метод
            Console.WriteLine(myfunc?.Invoke(2,8)); // сокращенный вызов с проверкой myfunc?.Invoke(2,8)


            //Пример использования предиката.
            //Найдем первый элемент в массиве < 3
            //Без использования лямда выражний 

            massiv[0] = 3;
            massiv[1] = 1;
            massiv[2] = 2;

            Predicate<int> predic = find;
            int first = Array.Find(massiv,find);
            Console.WriteLine(first);            
           
            //тоже самое, но с лямдой
            int first_2 = Array.Find(massiv,x=>x>=2); // Переменная x будет передаваться до деч пор в лямда выражение пока не будет выволнено условие x>=2
            Console.WriteLine(first_2);            
            

            //Пример лямды. Сокращенный способ анонимного метода    
            Func<int,int,int> funcSum = (x,y) => x+y;
            Console.WriteLine(funcSum(5,10));

            //анонимный метод

            MytestDelegate deleg = delegate(int x)
            {
               x = x*x;
               Console.WriteLine(x);
            };

            deleg.Invoke(6);
//
           //swdfsdsdfsfs
           

            int[] mas = new int[] {1,2,3,4,5,6,7,8,9};

            //Способ передачи в качестве аргумента функции.
            //Функция Sum возвращает сумму всех чисел в  массиве больше 5

            int x = Sum(mas,x => x>5);

            //public delegate bool delegtest(int p);
            // foreach (var item in mas)
            // {
            //     Console.WriteLine(item);
            // }

            //int result1 = Sum(mas, x => x > 5);

            Console.WriteLine(x);
            Console.ReadKey();

        }

     
        static int Sum(int[] numbers,Predicate<int> dlg)
        
        {

            int result = 0;
            foreach (var item in numbers)
            {
                if (dlg(item)) result+=item;    
            }
             
            return result;
        }

        static bool find(int x)
        {
            if (x < 3) return true; else return false;
       
        }

    }
}
