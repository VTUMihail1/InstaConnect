using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Models.DTOs.Account;
using InstaConnect.Data.Abstraction.Repositories;

namespace InstaConnect.Business.Services
{
    public class UserService
    {
        private readonly IMapper _mapper;
        private readonly IResultFactory _resultFactory;
        private readonly IFollowRepository _followRepository;

        public UserService(IMapper mapper, IResultFactory resultFactory, IFollowRepository followRepository)
        {
            _mapper = mapper;
            _resultFactory = resultFactory;
            _followRepository = followRepository;
        }
    }
}
