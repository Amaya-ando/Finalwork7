
namespace Online.Store;

class Program
{
    static void Main(string[] args)
    {
        //инициализация классов
        Customer customer1 = new("Lena", "CustomerAddress1");
        Customer customer2 = new("Oleg", "str. Lenina 467B");
        Shop shop1 = new("Shop1", "str. 8 marta 34I");
        HomeDelivery homeDelivery1 = new(customer2._name, customer2._address);
        ShopDelivery shopDelivery1 = new(shop1._name, customer1._name, shop1.Address);
        PickPointDelivery pickPointDelivery1 = new(customer2._name, "PikcPoint na reke - str. Karla Ruzvelta 45D");
        Product product1 = new("Gaming chair", 50000);
        Product product2 = new("Book", 32000);
        Product product3 = new("Comics", 2500);
        Courier courier1 = new("Cotyara", "345");
        Courier courier2 = new("Kirill", "346");
        Courier courier3 = new("Egor", "388");

        Order<HomeDelivery> order1 = new(1, homeDelivery1, product1, 1, courier1);
        Order<ShopDelivery> order2 = new(2, shopDelivery1, product2, 32, courier2);
        Order<PickPointDelivery> order3 = new(3, pickPointDelivery1, product3, 1, courier3);

        //вывод информации о заказах в консоль
        order1.DisplayOrderInfo();
        Console.WriteLine();
        order2.DisplayOrderInfo();
        Console.WriteLine();
        order3.DisplayOrderInfo();
        Console.WriteLine();

    }


}
abstract class Delivery // абстрактный базовый класс
{
    public string _address;

    public Delivery(string address)
    {

        _address = address;
    }
}

class HomeDelivery : Delivery // производный класс - "доставка на дом"
{
    public string _clientname;
    public HomeDelivery(string clientname, string address) : base(address)
    {
        _clientname = clientname;
    }
}

class PickPointDelivery : Delivery // производный класс - "доставка в пункт выдачи"
{
    public string _clientname;
    public PickPointDelivery(string clientname, string address) : base(address)
    {
        _clientname = clientname;
    }
}


class ShopDelivery : Delivery // производный класс - "доставка в магазин"
{
    public string _shopname;
    public string _clientname;
    public ShopDelivery(string shopname, string clientname, string address) : base(address)
    {
        _shopname = shopname;
        _clientname = clientname;
    }
}


class Order<TDelivery> where TDelivery : Delivery // обобщенный класс заказа
{
    public int _id;
    public TDelivery _delivery;
    public Product _product;
    public int Number;
    public Courier Courier;

    public void DisplayOrderInfo()
    {
        if (_delivery is HomeDelivery)
        {
            Console.WriteLine("Доставка на дом");
        }
        else if (_delivery is PickPointDelivery)
        {
            Console.WriteLine("Доставка в пункт выдачи");
        }
        else if (_delivery is ShopDelivery)
        {
            Console.WriteLine("Доставка в магазин");
        }
        Console.WriteLine($"Адрес: {_delivery._address}");
        Console.WriteLine($"Товар: {_product._name}");
        Console.WriteLine($"Стоимость товара: {_product._price}");
        Console.WriteLine($"Количество: {Number}");
        if (Courier != null)
        {
            Console.WriteLine($"Курьер: {Courier._name}");
        }
    }

    public Order(int id, TDelivery delivery, Product product, int number, Courier courier = null) //конструктор класса order
    {
        _id = id;
        _delivery = delivery;
        _product = product;
        Number = number;
        Courier = courier;
    }
}

class Product //продукт (логика имени и цены товара)
{
    public string _name;
    public int _price;
    public Product(string name, int price)
    {
        _name = name;
        _price = price;
    }
}

class Courier //курьер (логика имени и номера курьера)
{
    public string _name;
    public string _number;
    public Courier(string name, string number)
    {
        _name = name;
        _number = number;
    }
}

class Customer //клиент (логика имени и адреса)
{
    public string _name;
    public string _address;
    public Customer(string name, string address)
    {
        _name = name;
        _address = address;

    }
}

class Shop //магазин (логика имени магазина и адреса)
{
    public string _name;
    public string Address;
    public Shop(string name, string address)
    {
        _name = name;
        Address = address;
    }

}
