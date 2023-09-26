using InstaConnect.Business.Models.DTOs.Message;
using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Services
{
    public interface IMessageService
    {
        Task<ICollection<MessageResultDTO>> GetAllAsync(string senderId, string receiverId);
        Task<IResult<MessageResultDTO>> GetByIdAsync(string id);
        Task<IResult<MessageResultDTO>> GetBySenderIdAndReceiverIdAsync(string senderId, string receiverId);
        Task<IResult<MessageResultDTO>> AddAsync(string currentUserId, MessageAddDTO messageAddDTO);
        Task<IResult<MessageResultDTO>> UpdateAsync(string currentUserId, string id, MessageUpdateDTO messageUpdateDTO);
        Task<IResult<MessageResultDTO>> DeleteBySenderIdAndReceiverIdAsync(string currentUserId, string senderId, string receiverId);
        Task<IResult<MessageResultDTO>> DeleteAsync(string currentUserId, string id);
    }
}
