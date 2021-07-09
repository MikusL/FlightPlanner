// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using AutoMapper;
using FlightPlanner.App_Start;
using FlightPlanner.Core.Services;
using FlightPlanner.Data;
using FlightPlanner.Services;
using FlightPlanner.Services.Validators;
using StructureMap;

namespace FlightPlanner.DependencyResolution
{

    public class DefaultRegistry : Registry
    {
        #region Constructors and Destructors

        public DefaultRegistry()
        {
            Scan(
                scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    scan.With(new ControllerConvention());
                });
            //For<IExample>().Use<Example>();
            For<IDbService>().Use<DbService>();
            For<IFlightService>().Use<FlightService>();
            For<IAirportService>().Use<AirportService>();
            For(typeof(IEntityService<>)).Use(typeof(EntityService<>));
            For<IFlightPlannerDbContext>().Use<FlightPlannerDbContext>();
            For<IValidator>().Use<ArrivalDateValidator>();
            For<IValidator>().Use<DepartureTimeValidator>();
            For<IValidator>().Use<DatesIntervalValidator>();
            For<IValidator>().Use<CarrierValidator>();
            For<IValidator>().Use<AirportToValidator>();
            For<IValidator>().Use<AirportFromValidator>();
            For<IValidator>().Use<AirportCodesValidator>();

            var config = AutoMapperConfig.GetMapper();
            For<IMapper>().Use(config).Singleton();
        }

        #endregion
    }
}