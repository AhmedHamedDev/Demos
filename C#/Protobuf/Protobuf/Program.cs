using Protobuf;
using ProtoBuf;
using System.Text;

Product product1 = new() {
    Id = 1,
    Name = "tv",
    Quantity = 10,
    Price = 1000.0
};

Product product2 = new()
{
    Id = 2,
    Name = "phone",
    Quantity = 5,
    Price = 1500.0
};

Product product3 = new()
{
    Id = 3,
    Name = "pc",
    Quantity = 20,
    Price = 2000.0
};

var productsBeforeSerialize = new List<Product>() { product1, product2, product3 };

var stream = new MemoryStream();
Serializer.Serialize(stream, productsBeforeSerialize);

var readOnlyMemory = new ReadOnlyMemory<byte>(stream.ToArray());

var productsAfterDeSerialize = Serializer.Deserialize<List<Product>>(readOnlyMemory);
foreach (var product in productsAfterDeSerialize)
    Console.WriteLine(product);


//var productsBeforeSerialize = new List<Product>() { product1, product2, product3 };

//using (var file = File.Create("D:\\person.bin"))
//{
//    Serializer.Serialize(file, productsBeforeSerialize);
//}

//List<Product> productsAfterDeSerialize;
//using (var file = File.OpenRead("D:\\person.bin"))
//{
//    productsAfterDeSerialize = Serializer.Deserialize<List<Product>>(file);
//}

//foreach (var product in productsAfterDeSerialize)
//    Console.WriteLine(product);

Console.ReadKey();



