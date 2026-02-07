using static Clases2.Clases;

B b = new B();
A a = b;
a.F();
b.F();
a.G();
b.G();

Console.ReadKey();

/*
 * public class A
        {
            public void F() { Console.WriteLine("A.F"); }
            public virtual void G() { Console.WriteLine("A.G"); }
        }

        public class B : A
        {
            new public void F() { Console.WriteLine("B.F"); }
            public override void G() { Console.WriteLine("B.G"); }
        }
 * 
 * Output: 
 * A.F
 * B.F
 * B.G
 * B.G
 */