namespace StarterMicroservice.API
{
    internal static class ApiExtensions
    {
        public static void AddApiEndpoints(this WebApplication app)
        {
            var userGroup = app.MapGroup("/MyUser")
                .WithTags("MyUser");

            // Add endpoints here
            userGroup.MapGet("GetMyUser", async (int userId, MyUserContext db) =>
            {
                var user = await db.Users.FindAsync(userId);

                return user is not null
                    ? Results.Ok(user)
                    : Results.NotFound();
            })
            .Produces<MyUser>();
        }
    }
}