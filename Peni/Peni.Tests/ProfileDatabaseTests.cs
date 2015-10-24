using System;
using NUnit.Framework;
using Peni.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin.UITest;

namespace Peni.Tests
{
	[TestFixture (Platform.Android)]
	public class ProfileDatabaseTests
	{
		IApp app;
		Platform platform;

		public ProfileDatabaseTests(Platform platform) {
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest() {
			app = AppInitializer.StartApp (platform);
		}

		[Test]
		public async Task AttemptToAddAndDeleteProfile() {
			ProfileDatabase database = new ProfileDatabase ();
			Account AccountToAdd = new Account () {
				Email = "FKEFACM@fAFKWQCM.COM",
				Username = "FKAWQEIcF93VJ#W#oLF",
				Password = "",
				UserStage = 5,
				UserBio = "",
				UserStatus = "",
				UserPrivacy = false
			};

			await database.InsertProfile (AccountToAdd);
			List<Account> FoundAccounts = new List<Account> (await database.AttemptLogin (AccountToAdd.Email, AccountToAdd.Password));

			Assert.AreEqual(1, FoundAccounts.Count);
			Assert.IsTrue(await database.AttemptDeleteProfile (AccountToAdd.Email, AccountToAdd.Password));
		} 

		[Test]
		public void TestingTest() {
			Assert.AreEqual (1, 1);
		}
	}
}

