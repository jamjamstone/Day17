namespace Day17
{



    class Beagle
    {

        /**클래스 모든 인스턴스가 공유하는 변수->스태틱 필드->클래스 자체에 속한다
         * 심지어는 인스턴스가 없어도 사용가능하다-> 클래스 선언 없이도 사용 가능
         */
        /**스태틱 함수-> 인스턴스 없이 실행 가능한 함수, console함수가 대표적인 예
         * 구조체에도 작성 가능 int.Parse에서 int 는 구조체이고 Parse는 스태틱 함수이다.
         * 이런 함수는 주로 유틸리티 함수에 자주 사용됨
         * 
         * 
         * 
         */
        
        static Random random;
        static int _createCount; //비글 생성 개수
        string _name;
        public static Random Random
        {
            get
            {
                if (random == null)
                {
                    random = new Random();
                }
                return random;
            }


        }

    }/*
    class Character
    {
        protected string _name;
        public void Move()
        {
            Console.WriteLine($"{_name} 이동합니다."); 
        }
        public Character(string name)
        {
            _name = name;
        }
        public Character()
        {
            _name = "default";
        }
        public Character(string name,int noMean)
        {
            _name = name;
        }
        public void Attack()
        {
            
            Console.WriteLine($"{_name} 캐릭터 공격합니다.");
        }
    }

    class Player:Character
    {
       public void Attack()
        {
            base.Attack();
            Console.WriteLine($"{_name} 공격합니다.");
        }
        public Player(string name) :base(name) 
        {
            _name = name;
        }
    }
    class Enemy:Character
    {
        public void Taunt()
        {
            Console.WriteLine($"{_name } 도발합니다.");
        }
    }

    class Car
    {
        protected float _maxSpeed;
        protected string _brand;

        public virtual void Drive()// virtual -> 가상의, 이 단어를 붙여 오버라이드 가능
        {
            Console.WriteLine("주행");
        }
    }

    class Sedan : Car
    {
        public void SedanAction()
        {
            Console.WriteLine("동승자 태우기");
        }
        public void Drive()
        {
            Console.WriteLine("sedan 주행");
        }


    }

    class Truck : Car
    {
        public void TruckAction()
        {
            Console.WriteLine("짐싣기");
        }
        public sealed override void Drive()// sealed를 통해서 오버라이드를 하지 못하게 막을 수 있음
        {
            Console.WriteLine("오프로드 주행");
        }
    }

    class Bulldoser : Car
    {
        public new void BulldoserAction()//new는 함수를 새로 만들어서 사용함 부모 클래스의 
            //정체를 숨겨서 하이딩이라고 부른다.
        {
            Console.WriteLine("평탄화작업");
        }
        //필요에 따라 파생클래스에서 재정의 하는 것을 보고 오버라이드 한다고 표현
        // 오버로딩은 함수 이름만 같고 매개변수만 다른 내용을 덮어 씌움
        public override void Drive()//override를 붙이면 같은 명의 함수를 덮어씌워서 다형성을 사용해도 쉽게 사용가능 
        {
            Console.WriteLine("저속 주행");
        }
    }
    class TwotonHalf : Truck
    {

        new float _maxSpeed;//new를 통해서 인스턴스만의 맥스 스피드 채용 가능, 필드 하이딩
        new public void Drive()
        {
            float _maxSpeed=50;//변수를 찾을 때 가장 가 까운 순서대로 
            Console.WriteLine("작전 주행");
            Console.WriteLine(_maxSpeed);
            Console.WriteLine(this._maxSpeed);
            Console.WriteLine(base._maxSpeed);
        }

    }*/

    abstract class Character// 추상화 클래스 ->불완전한 클래스가 되었음
    {
        protected string _name;
        protected decimal _shilling;// 정확한 숫자가 필요할 때 사용
        protected uint _storyProgress;
        public void ShowMoney()
        {
            Console.WriteLine($"잔액 {_shilling}");
        }
        public abstract void BaseAttack();// 타 언어 순수가상함수-> 추상함수 BaseAttack
        //함수는 존재해야 하지만 구현은 파생클래스에 맡기는 코드->abstract
        
    }
    class Mage : Character 
    {
        string _staffType = "Basic staff";
        public override void BaseAttack()
        {
            Console.WriteLine(_staffType+"magic!");
        }
        public void Teleport()
        {
            Console.WriteLine("순간이동");
        }
    }
    class Hunter : Character
    {
        string _gunType = "Basic gun";
        public override void BaseAttack()
        {
            Console.WriteLine(_gunType+"shot!");
        }

        public void Roll()
        {
            Console.WriteLine("구른다");
        }

    }

    internal class Program
    {
        /** 다형성
         * 객체지향 프로그래밍에서 필요에 따라 형태를 바꿀 수 있는 것을 다형성이라고 함
         * 다양하게 형을 바꾼다는 뜻
         * 
         * 
         * 추상 클래스 -> 세부적인 구현은 자식클래스가 하도록 위임하고 본인은 최소한의 
         * 기능만을 가지고 있는 클래스
         * 
         */




        static void Main(string[] args)//메인이 스태틱이기 때문에 외부 변수는 스태틱이어야 함
        {

            Character hunter = new Hunter();// 다형성은 추상클래스에도 사용가능 
            Mage mage = new Mage();

            mage.Teleport();
            Character witch = new Mage();
            Character[] party = { new Hunter(), new Mage() };
           if(witch is Mage)//is는 이 자료형이 무엇으로 만들었는지 확인하기
            {
                ((Mage)witch).Teleport();//Mage형으로 강제 형변환

                (witch as Mage)?.Teleport();// 형변환 실패시 null 반환
                Console.WriteLine("mage");
            }

           if(witch as Mage !=null)
            {
                (witch as Mage).Teleport();// 아래의 코드와 같다
            }

                (witch as Mage)?.Teleport();//위의 코드와 같다


            Random rd = null;
            Console.WriteLine(rd?.Next());//
           foreach(var character in party)
            {
                character.BaseAttack();
            }


            //as 의경우 무엇으로 변경하시오
            //? 키워드 -> null이 가능한 형에 ?를 붙이면 만약 null일 경우 
            //뒤에 오는 모든 코드를 재낀다. -> null 조건부 연산자







            //Beagle beagle = new Beagle();
            //Console.WriteLine(Beagle.Random.Next(1,5));
            //Console.WriteLine(Beagle.Random.Next(1, 5));
            //Console.WriteLine(Beagle.Random.Next(1, 5));
            //Player player = new Player("sdfasdf");
            //int a=0;
            //a.CompareTo(1);//모든 자료형은 오브젝트를 상속받는다.
            //Sedan sedan = new Sedan();
            //Bulldoser bulldoser = new Bulldoser();
            //Truck truck = new Truck();//주차장 운영 프로그램 혹은 시뮬레이터 
            //Truck[] trucks = new Truck[11];
            //Bulldoser[] bulldosers = new Bulldoser[11];
            //Car car=new Sedan();//세단형 객체를 만들고 Car형에 담았다. 필요에 따라 형을 바꿈
            //Car bull= new Bulldoser();
            //Car truck = new Truck();//상속관계에서만 가능
            //Car[] garage = new Car[3];//다형성을 이용 다른 클래스의 객체를 한 클래스의 배열에 담는 것이 가능
            //garage[0] = bull;
            //garage[1] = truck;
            //garage[2] = car;
            //오버라이드 상속관계에서 부모클래스의 메소드를 자식클래스가 재정의 해서 사용
            //또는 덮어씌우고 본인만의 기능르 새로만드는 것을 보고 오버라이딩이라고 부름
            //Car bulldoser = new Bulldoser();
            //Car truck = new Truck();
            //Sedan  sedan = new Sedan();
            //bulldoser.Drive();
            //truck.Drive();
            //TwotonHalf t= new TwotonHalf();
            //t.Drive();
        }
    }
    
}
