using Backend.Contexts;
using Backend.Models.DTO;
using Backend.Models.Entities;

namespace Backend.Repositories
{
    public class MessageRepository
    {

        private readonly DataContext _context;

        public MessageRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<MessageEntity> GetMessage(MessageRequest request)
        {
            _context.Messages.Add(request);
            await _context.SaveChangesAsync();

            return request;
        }
    }
}
