using AutoMapper;
using BowlingScoreCalculator.WebAPI.Models.Request;
using BowlingScoreCalculator.WebAPI.Models.Response;
using BLLModelsRequest = BowlingScoreCalculator.BLL.Models.Request;
using BLLModelsResponse = BowlingScoreCalculator.BLL.Models.Response;

namespace BowlingScoreCalculator.WebAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<GetScoreProgressRequest, BLLModelsRequest.GetScoreProgressRequest>()
                .ForMember(dest => dest.PinsDowned, opt => opt.MapFrom(src => src.PinsDowned));
            CreateMap<BLLModelsResponse.GetScoreProgressResponse, GetScoreProgressResponse>()
                .ForMember(dest => dest.FrameProgressScores, opt => opt.MapFrom(src => src.FrameProgressScores))
                .ForMember(dest => dest.GameCompleted, opt => opt.MapFrom(src => src.GameCompleted));
        }
    }
}
