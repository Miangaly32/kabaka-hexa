using AutoMapper;
using Core.DTO.IngredientQuantity;
using Core.DTO.Ingredients;
using Core.DTO.Meal;
using Core.Models;

namespace Core.Profiles;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<AddIngredientDto, Ingredient>();
        CreateMap<AddMealDto, Meal>();
        CreateMap<AddIngredientQuantityDto, IngredientQuantity>();
        CreateMap<UpdateIngredientDto, Ingredient>();
        CreateMap<UpdateMealDto, Meal>();
        CreateMap<Ingredient, GetIngredientDto >();
        CreateMap<Meal, GetMealDto >();
        CreateMap<Meal, GetMealDto >().ReverseMap();
        CreateMap<IngredientQuantity, GetIngredientQuantityDto >();
    }
}