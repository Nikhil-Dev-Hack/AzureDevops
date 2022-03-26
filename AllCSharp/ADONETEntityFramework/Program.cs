using ADONETEntityFramework.CRUID_Operations;
using ADONETEntityFramework.CRUID_Operations.ProductFolder;
using System;

namespace ADONETEntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            #region ProductTable
            #region ProductInsertion
            //new ProductTableInsertion().InsertProductWayOne("Sample",78900,45,"Sample");
            //new ProductTableInsertion().InsertProductWayTwo();
            #endregion

            #region ProductUpdate
            //new ProductUpdate().Update();
            #endregion

            #region ReadTheProducts
            //new ReadTheProducts().Read();
            #endregion

            #region DeleteTheProductInfo
            //new DeleteInfoFromProducts().Delete();
            #endregion
            #endregion

            #region CustomerTable



            #endregion
        }
    }
}
