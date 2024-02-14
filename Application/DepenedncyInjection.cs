﻿using Application.Models;
using Domain.Models.Shiki;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
	public static class DepenedncyInjection
	{
		public static IServiceCollection AddApplication(this IServiceCollection services) {
			services.AddMediatR(Assembly.GetExecutingAssembly());

            RegisterMapper(services);

            return services;
		}

		private static IServiceCollection RegisterMapper(IServiceCollection services) {
            var config = new TypeAdapterConfig();

            const string shikiUrl = "https://shikimori.one";

            config.NewConfig<AnimeId, AnimePageVM>()
                .Map(dest => dest.Image.Original, src => $"{shikiUrl}{src.Image.Original}")
                .Map(dest => dest.Image.Preview, src => $"{shikiUrl}{src.Image.Preview}")
                .Map(dest => dest.Image.X96, src => $"{shikiUrl}{src.Image.X96}")
                .Map(dest => dest.Image.X48, src => $"{shikiUrl}{src.Image.X48}")
                .RequireDestinationMemberSource(true);

            config.NewConfig<Anime, AnimePageVM>()
                .Map(dest => dest.Image.Original, src => $"{shikiUrl}{src.Image.Original}")
                .Map(dest => dest.Image.Preview, src => $"{shikiUrl}{src.Image.Preview}")
                .Map(dest => dest.Image.X96, src => $"{shikiUrl}{src.Image.X96}")
                .Map(dest => dest.Image.X48, src => $"{shikiUrl}{src.Image.X48}")
                .RequireDestinationMemberSource(true);

            config.NewConfig<AnimeId, AnimeFullVM>()
                .Map(dest => dest.Image.Original, src => $"{shikiUrl}{src.Image.Original}")
				.Map(dest => dest.Image.Preview, src => $"{shikiUrl}{src.Image.Preview}")
				.Map(dest => dest.Image.X96, src => $"{shikiUrl}{src.Image.X96}")
				.Map(dest => dest.Image.X48, src => $"{shikiUrl}{src.Image.X48}")
				.RequireDestinationMemberSource(true);

			services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();

            return services;
        }
    }
}
