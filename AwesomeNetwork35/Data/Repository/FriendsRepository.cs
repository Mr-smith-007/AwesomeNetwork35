using AwesomeNetwork35.Models.Users;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AwesomeNetwork35.Data.Repository
{
    public class FriendsRepository : Repository<Friend>
    {
        public FriendsRepository(ApplicationDbContext db): base(db) {}

        public void AddFriend(User target, User Friend)
        {
            var friends = Set.AsEnumerable().FirstOrDefault(x => x.UserId == target.Id && x.CurrentFriendId == Friend.Id);

            if (friends == null)
            {
                var item = new Friend()
                {
                    UserId = target.Id,
                    User = target,
                    CurrentFriend = Friend,
                    CurrentFriendId = Friend.Id,
                };

                Create(item);
            }
        }

        public async Task<List<User>> GetFriendsByUser(User target)
        {
            var friends = Set.Include(x => x.CurrentFriend).AsQueryable().Where(x => x.User.Id == target.Id).Select(x => x.CurrentFriend);

            if (friends is null)
                return new List<User>();
            else
                return await friends.ToListAsync();
        }


        public void DeleteFriend(User target, User Friend)
        {
            var friends = Set.AsEnumerable().FirstOrDefault(x => x.UserId == target.Id && x.CurrentFriendId == Friend.Id);

            if (friends != null)
            {
                Delete(friends);
            }
        }
    }
}
