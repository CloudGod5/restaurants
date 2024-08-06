﻿using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos; 
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants;

internal class RestaurantsService(IRestaurantsRepository restaurantsRepository,
    ILogger<RestaurantsService> logger) : IRestaurantsService
{
    public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
    {
        logger.LogInformation("Getting all Restaurants");
        var restaurants = await restaurantsRepository.GetAllAsync();
        var restaurantsDtos = restaurants.Select(RestaurantDto.FromEntity);

        return restaurantsDtos!;
    }

    public async Task<RestaurantDto?> GetById(int id)
    {
        logger.LogInformation($"Getting restaurant by {id}");
        var restaurant = await restaurantsRepository.GetByIdAsync(id);
        var restaurantsDto = RestaurantDto.FromEntity(restaurant);

        return restaurantsDto;
    }
}
