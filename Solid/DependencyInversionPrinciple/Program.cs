using System.Net.Quic;

class Program
{
    static void Main(string[] args)
    {
        var sql = new SqlDatabase();
        var mng = new MongoDatabase();

        OrderService oderService = new OrderService(mng);
        oderService.Save();
    }
}
