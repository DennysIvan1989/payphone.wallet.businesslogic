using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using payphone.wallet.businesslogic.Dto.Wallet;
using payphone.wallet.businesslogic.Transacciones;
using payphone.wallet.businesslogic.Utils;
using payphone.wallet.persistence.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace payphone.wallet.businesslogic.Transacciones.Tests
{
    [TestClass()]
    public class WalletServicesTests
    {
        private ServiceProvider _sProvider;

        [TestInitialize]
        public void StartUp()
        {

            var services = new ServiceCollection();
            services.AddDbContext<WalletDbContext>(options => options.UseLazyLoadingProxies().UseSqlServer("Server=DESKTOP-UDDT6VH;Database=PayPhoneDB;Trusted_Connection=True;TrustServerCertificate=True;"));
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            services.AddScoped<IWallet, WalletServices>();
            services.AddScoped<IWalletMovement, WalletMovementService>();
            _sProvider = services.BuildServiceProvider();
        }

        [TestMethod()]
        public void CreateWalletTest()
        {
            try
            {

                //Init Scope
                using var scope = _sProvider.CreateScope();
                var wallerService = scope.ServiceProvider.GetService<IWallet>();
                var context = scope.ServiceProvider.GetRequiredService<WalletDbContext>();
                var wallet = new WalletDto()
                {
                    DocumentId = "0604112649",
                    Name = "Dennys Moyón",
                    Balance = 20.25M,
                    State = "A",
                    Locks = 0M,
                    CalendarAt = new DateTime(2025, 8, 28),
                    UserCreate = "pytest",
                    CreateAt = DateTime.Now,
                    Active = true
                };

                var respuesta = wallerService.CreateWallet(wallet);
                if (respuesta.Correcto)
                    context.SaveChanges();

                Assert.IsTrue(respuesta.Correcto);
            }
            catch (Exception ex)
            {

                Assert.Fail(ex.Message);
            }

        }

        [TestMethod()]
        public void UpdateWalletTest()
        {
            try
            {

                // Init Scope
                using var scope = _sProvider.CreateScope();
                var wallerService = scope.ServiceProvider.GetService<IWallet>();
                var context = scope.ServiceProvider.GetRequiredService<WalletDbContext>();
                var wallet = new WalletDto()
                {
                    Id = 1,
                    DocumentId = "0604112649",
                    Name = "Dennys Ivan Moyón",
                    Balance = 0M,
                    State = "A",
                    Locks = 0M,
                    CalendarAt = new DateTime(2025, 8, 28),
                    UserCreate = "pytest",
                    CreateAt = DateTime.Now,
                    Active = true
                };

                var respuesta = wallerService.UpdateWallet(1, wallet);
                if (respuesta.Correcto)
                    context.SaveChanges();

                Assert.IsTrue(respuesta.Correcto);
            }
            catch (Exception ex)
            {

                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void GetWalletTest()
        {
            try
            {

                // Init Scope
                using var scope = _sProvider.CreateScope();
                var wallerService = scope.ServiceProvider.GetService<IWallet>();
                var respuesta = wallerService.GetWalletForState("A");
                Assert.IsTrue(respuesta.Correcto);
            }
            catch (Exception ex)
            {

                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void CreateMovement()
        {
            try
            {

                // Init Scope
                using var scope = _sProvider.CreateScope();
                var wallerMovService = scope.ServiceProvider.GetService<IWalletMovement>();
                var context = scope.ServiceProvider.GetRequiredService<WalletDbContext>();
                var movW = new WalletMovementDto()
                {
                    WalletId = 3,
                    Amount = 3.23M,
                    Type = "A",
                    CalendarAt = new DateTime(2025, 8, 28),
                    UserCreate = "pytest",
                    CreateAt = DateTime.Now,
                    Active = true,
                    Document = DateTime.Now.Ticks.ToString()
                };
                var respuesta = wallerMovService.CreateMovement(movW);
                if (respuesta.Correcto) {
                    context.SaveChanges();
                }
                Assert.IsTrue(respuesta.Correcto);
            }
            catch (Exception ex)
            {

                Assert.Fail(ex.Message);
            }
        }
    }
}