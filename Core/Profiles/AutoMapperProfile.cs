using AutoMapper;
using Core.DTO.Ingredients;
using Core.Models;

namespace Core.Profiles;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<AddIngredientDto, Ingredient>();
        CreateMap<UpdateIngredientDto, Ingredient>();
        CreateMap<Ingredient, GetIngredientDto >();
    }
}