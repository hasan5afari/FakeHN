<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Top3Controller.ascx.cs" Inherits="FakeHN.UIL.controls.Top3Controller" %>

<div id="carouselTOP3" runat="server" class="carousel slide carousel-dark bg-light rounded m-1 m-sm-2 m-md-3 m-lg-4" data-bs-ride="carousel">
    <div class="carousel-indicators">
        <button type="button" data-bs-target="#carouselTOP3" data-bs-slide-to="0" aria-label="Slide 1" class="active"></button>
        <button type="button" data-bs-target="#carouselTOP3" data-bs-slide-to="1" aria-label="Slide 2"></button>
        <button type="button" data-bs-target="#carouselTOP3" data-bs-slide-to="2" aria-label="Slide 3"></button>
    </div>
    <div class="carousel-inner" runat="server" id="top3CarouselContent"></div>
    <button runat="server" id="nextButton" type="button" class="carousel-control-prev" data-bs-target="#carouselTOP3" data-bs-slide="prev">
        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
        <span class="visually-hidden">Previous</span>
    </button>
    <button runat="server" id="prevButton" type="button" class="carousel-control-next" data-bs-target="#carouselTOP3" data-bs-slide="next">
        <span class="carousel-control-next-icon" aria-hidden="true"></span>
        <span class="visually-hidden">Next</span>
    </button>
</div>