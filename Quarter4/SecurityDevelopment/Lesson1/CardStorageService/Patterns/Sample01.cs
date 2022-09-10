namespace Patterns
{
    internal class Sample01
    {
        static void Main(string[] args)
        {

            #region Adapter

            var myClient = new MyClient();
            myClient.Request(new Target());
            myClient.Request(new Adapter());

            #endregion

            #region Facade

            Facade facade = new Facade(new SystemA(), new SystemB(), new SystemC());
            facade.DoWork3();

            #endregion

            #region Decorator

            FinalWorkComponent1 finalWorkComponent1 = new FinalWorkComponent1();
            finalWorkComponent1.DoWork();

            finalWorkComponent1.SetComponent(new WorkComponent());
            finalWorkComponent1.DoWork();

            #endregion

            Console.ReadKey();
        }
    }

    #region Adapter

    class MyClient
    {
        public void Request(Target target)
        {
            target.Request();
        }
    }

    class Adapter : Target
    {
        private SpecificTarget specificTarget = new SpecificTarget();

        public override void Request()
        {
            specificTarget.SpecificRequest();
        }
    }

    class Target
    {
        public virtual void Request()
        {
            Console.WriteLine("Do work (1) ....");
        }
    }

    class SpecificTarget
    {
        public void SpecificRequest()
        {
            Console.WriteLine("Do work (2) ....");
        } 
    }

    #endregion

    #region Facade

    public class SystemA
    {
        public void DoProcessA1()
        {

        }

        public void DoProcessA2()
        {

        }

        public void DoProcessA3()
        {

        }
    }

    public class SystemB
    {
        public void DoProcessB1()
        {

        }

        public void DoProcessB2()
        {

        }
    }

    public class SystemC
    {
        public void DoProcessC()
        {

        }
    }

    public class Facade
    {
        private SystemA _systemA;
        private SystemB _systemB;
        private SystemC _systemC;

        public Facade(SystemA systemA, SystemB systemB, SystemC systemC)
        {
            _systemA = systemA;
            _systemB = systemB;
            _systemC = systemC;
        }

        public void DoWork1()
        {
            _systemA.DoProcessA1();
            _systemB.DoProcessB2();
        }

        public void DoWork2()
        {
            _systemA.DoProcessA3();
            _systemA.DoProcessA1();
            _systemC.DoProcessC();
        }

        public void DoWork3()
        {
            _systemB.DoProcessB2();
            _systemC.DoProcessC();
        }

    }

    #endregion

    #region Decorator

    abstract class BaseComponent
    {
        public abstract void DoWork();
    }

    class WorkComponent : BaseComponent
    {
        public override void DoWork()
        {
            Console.WriteLine("Do work ...");
        }
    }
    
    abstract class WorkDecoratorComponent : BaseComponent
    {
        protected BaseComponent baseComponent;

        public void SetComponent(BaseComponent baseComponent)
        {
            this.baseComponent = baseComponent;
        }

        public override void DoWork()
        {
            if (baseComponent != null)
            baseComponent.DoWork();
        }

    }

    class FinalWorkComponent1 : WorkDecoratorComponent
    {
        public override void DoWork()
        {
            if (base.baseComponent != null)
                base.baseComponent.DoWork();
            else
                Console.WriteLine("Final DoWork (1) ...");
        }
    }

    class FinalWorkComponent2 : WorkDecoratorComponent
    {
        public override void DoWork()
        {
            Console.WriteLine("Final DoWork (2) ...");
        }
    }

    #endregion


}