<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TLPostController.ascx.cs" Inherits="FakeHN.UIL.controls.TLPostController" %>

<div class='row w-100'>
    <!-- timeline icons -->
    <div class='col-2 col-md-3'>
        <div class='timeline-time'>
            <span runat="server" id="dateContainer" class='date'></span>
            <span runat="server" id="timeContainer" class='time'></span>
        </div>
        <div class='timeline-icon'>
            <a href = 'javascript:;' > &nbsp;</a>
        </div>
    </div>

    <!-- body -->
    <div class='col-10 col-md-8'>
        <div class='timeline-body ms-5 me-3 ps-0 pe-0 me-sm-4 ms-md-1 me-md-5 '>
            <div class='timeline-header'>
                    <svg xmlns = 'http://www.w3.org/2000/svg' width='32' height='32' fill='currentColor' class='bi bi-person-circle' viewBox='0 0 16 16'>
                    <path d = 'M11 6a3 3 0 1 1-6 0 3 3 0 0 1 6 0z' />
                    <path fill-rule='evenodd' d='M0 8a8 8 0 1 1 16 0A8 8 0 0 1 0 8zm8-7a7 7 0 0 0-5.468 11.37C3.242 11.226 4.805 10 8 10s4.757 1.225 5.468 2.37A7 7 0 0 0 8 1z'/>
                    </svg>
                <span runat="server" id="postAuthorName" class='username ps-2 h6 text-black'></span>
                <span class='pull-right text-muted'>
                <div runat="server" id='postVotes' class='row upvote'>
                    <div class='col-1'>
                    <svg runat="server" id = 'upvoteIcon' xmlns='http://www.w3.org/2000/svg' width='28' height='28' fill='currentColor' class='bi bi-arrow-up-short' viewBox='0 0 16 16'>
                        <path fill-rule='evenodd' d='M8 12a.5.5 0 0 0 .5-.5V5.707l2.146 2.147a.5.5 0 0 0 .708-.708l-3-3a.5.5 0 0 0-.708 0l-3 3a.5.5 0 1 0 .708.708L7.5 5.707V11.5a.5.5 0 0 0 .5.5z'/>
                    </svg>
                    </div>
                    <div runat="server" id = 'upvoteText' class='col'>
                    </div>
                </div>
                </span>
            </div>
            <div class='timeline-content'>
                <p runat="server" id="postBodyText"></p>
            </div>

            <!-- Like and comments -->
            <div class='timeline-likes'>
                <div class='stats-left'>
                    <a runat="server" id='commentSectionLink' href = '#allComments' class='stats-text text-muted text-decoration-none' data-bs-toggle='collapse'></a>
                    <div runat="server" id = 'allComments' class='collapse container-fluid comments-container mt-4'>
                        
                    </div>
                </div>
                <div class='stats'>
                    <span>&nbsp;</span>
                </div>
            </div>

            <!-- Footer -->
            <div class='timeline-footer'>
                <a runat="server" id="linkToCommentBox" href = '#commentBox' class='text-decoration-none m-r-15 text-inverse-lighter' data-bs-toggle='collapse'>
                    <svg xmlns = 'http://www.w3.org/2000/svg' width='16' height='16' fill='currentColor' class='bi bi-chat-left-text' viewBox='0 0 16 16'>
                        <path d = 'M14 1a1 1 0 0 1 1 1v8a1 1 0 0 1-1 1H4.414A2 2 0 0 0 3 11.586l-2 2V2a1 1 0 0 1 1-1h12zM2 0a2 2 0 0 0-2 2v12.793a.5.5 0 0 0 .854.353l2.853-2.853A1 1 0 0 1 4.414 12H14a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2H2z' />
                        <path d='M3 3.5a.5.5 0 0 1 .5-.5h9a.5.5 0 0 1 0 1h-9a.5.5 0 0 1-.5-.5zM3 6a.5.5 0 0 1 .5-.5h9a.5.5 0 0 1 0 1h-9A.5.5 0 0 1 3 6zm0 2.5a.5.5 0 0 1 .5-.5h5a.5.5 0 0 1 0 1h-5a.5.5 0 0 1-.5-.5z'/>
                    </svg>
                    Comment
                </a>
                <div runat="server" id='commentBox' class='collapse'>
                    <div class='timeline-comment-box bg-transparent'>
                        <div class='user mt-1 ms-1'>
                            <svg xmlns = 'http://www.w3.org/2000/svg' width='28' height='28' fill='currentColor' class='bi bi-person-circle' viewBox='0 0 16 16'>
                                <path d = 'M11 6a3 3 0 1 1-6 0 3 3 0 0 1 6 0z' />
                                <path fill-rule='evenodd' d='M0 8a8 8 0 1 1 16 0A8 8 0 0 1 0 8zm8-7a7 7 0 0 0-5.468 11.37C3.242 11.226 4.805 10 8 10s4.757 1.225 5.468 2.37A7 7 0 0 0 8 1z'/>
                            </svg>
                        </div>
                        <div class='input'>
                            <form >
                                <div class='input-group'>
                                    <input runat="server" id='commentInput' type = 'text' class='form-control rounded-corner' placeholder='Write a comment...'>
                                    <span class='input-group-btn p-l-10'>
                                        <button runat="server" id='commentButton' class='btn btn-primary f-s-12 rounded-corner' type='button'>Comment</button>
                                    </span>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>