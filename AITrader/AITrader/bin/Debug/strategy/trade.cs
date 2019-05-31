       public class TestClass222
        {
            private int value = 0;

            public void TestPrint(int num)
            {
                value = num * num;
                throw new Exception();
            }

            public static void TestStaticPrint()
            {
                //return "CSharp" + "TestStaticPrint";
                throw new Exception();

            }
        }