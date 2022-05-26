<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PostCommentController.ascx.cs" Inherits="FakeHN.UIL.controls.PostCommentController" %>

<div class='comment w-100'>
    <div class='comment-header mt-2 mx-1 mx-md-4'>
        <div class='row w-100 mb-2'>
        <div class='col-auto pe-1'>
            <svg xmlns = 'http://www.w3.org/2000/svg' width='24' height='24' fill='currentColor' class='bi bi-person-circle' viewBox='0 0 16 16'>
            <path d = 'M11 6a3 3 0 1 1-6 0 3 3 0 0 1 6 0z' />
            <path fill-rule='evenodd' d='M0 8a8 8 0 1 1 16 0A8 8 0 0 1 0 8zm8-7a7 7 0 0 0-5.468 11.37C3.242 11.226 4.805 10 8 10s4.757 1.225 5.468 2.37A7 7 0 0 0 8 1z'/>
            </svg>
        </div>
        <div class='col ps-0' style='padding-top: 2px;'>
            <span runat="server" id="commentAuthor" class='h6 text-black'></span> <span class='text-muted'>said</span>:
        </div>
        </div>
    </div>
    <div class='comment-body ps-5'>
        <p runat="server" id="commentBody"></p>
    </div>
</div>