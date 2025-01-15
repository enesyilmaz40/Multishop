﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using MultiShop.WebUI.Services.CatalogServices.SpecialOfferService;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{

    [Area("Admin")]

    [Route("Admin/SpecialOffer")]
    public class SpecialOfferController : Controller
    {
   private readonly ISpecialOfferService _specialOfferService;

        public SpecialOfferController(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }
        void SpecialOfferVieBagList()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Özel Teklifler";
            ViewBag.v3 = "Özel Teklif Ve Günün İndirim Listesi";
            ViewBag.v0 = "Özeli Teklif İşlemleri";
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {

            SpecialOfferVieBagList();

            var values = await _specialOfferService.GetAllSpecialOfferAsync();
            return View(values);
        }
        [HttpGet]
        [Route("CreateSpecialOffer")]
        public IActionResult CreateSpecialOffer()
        {
            SpecialOfferVieBagList();
            return View();
        }
        [HttpPost]
        [Route("CreateSpecialOffer")]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {

            await _specialOfferService.CreateSpecialOfferAsync(createSpecialOfferDto);


            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }

        [Route("DeleteSpecialOffer/{id}")]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            await _specialOfferService.DeleteSpecialOfferAsync(id);

            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }
        [Route("UpdateSpecialOffer/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateSpecialOffer(string id)
        {
            SpecialOfferVieBagList();

            var values = await _specialOfferService.GetByIdSpecialOfferAsync(id);
            return View(values);
        }
        [Route("UpdateSpecialOffer/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _specialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDto);
            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }
    }
}
