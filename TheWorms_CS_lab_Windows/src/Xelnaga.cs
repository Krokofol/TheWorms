﻿using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using TheWorms_CS_lab_Windows.services;

namespace TheWorms_CS_lab_Windows
{
    public class Xelnaga : IHostedService
    {
        private readonly FoodService _foodService;
        private readonly IntellectualService _intellectualService;
        private readonly NameService _nameService;
        private readonly ReportService _reportService;
        
        public Xelnaga()
        {
            _foodService = new FoodService();
            _intellectualService = new IntellectualService();
            _nameService = new NameService();
            _reportService = new ReportService();
        }
        
        public Task StartAsync(CancellationToken cancellationToken)
        {
            var god = new WormsGod(
                _foodService,
                _intellectualService,
                _nameService,
                _reportService
            );
            god.DoGodsJob();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}