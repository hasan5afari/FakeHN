<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createPost.aspx.cs" Inherits="FakeHN.UIL.createPost" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Create Post</title>

    <!-- stylesheets -->
    <link rel="stylesheet" href="style/style.css" />
    <link rel="stylesheet" href="style/bootstrap.min.css" />
    <link
      href="https://maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css"
      rel="stylesheet"
    />
</head>
<body>

    <form runat="server">
        <!-- header section -->
        <header>

          <!-- navigation bar -->
          <nav class="navbar navbar-light bg-light navbar-expand-sm">
            <div class="container-fluid">
              <a id="navbarBrand" href="#" class="navbar-brand">FakeHN</a>
              <button type="button" class="navbar-toggler" data-bs-toggle="collapse" data-bs-target="#navigationBar" aria-controls="navbarResponsiveRight" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
              </button>
              <div class="collapse navbar-collapse me-auto" id="navigationBar">
                <ul class="navbar-nav">
                  <li class="nav-item">
                    <a href="index.aspx" class="nav-link active" aria-current="page">Home</a>
                  </li>
                  <li class="nav-item">
                    <a href="About.aspx" class="nav-link">About</a>
                  </li>
                </ul>
                <div id="createUserINFO" runat="server" class="container d-inline-flex align-items-center justify-content-center justify-content-sm-end"></div>
              </div>
            </div>
          </nav>

        </header>

        <main>
            <div class="w-100" id="createPostForm">
                <div class="card text-center mx-5 login-card my-5">
                    <div class="card-header">
                    Edit Post
                    </div>
                        <div class="card-body">
                            <div class="container-fluid d-flex justify-content-center align-align-items-center mt-3  w-100 h-100">
                                <textarea id="createPostTextArea" runat="server" class="d-block mb-2 w-100" style="flex: 0 0 100%; height:100px" required ></textarea>
                            </div>
                            <asp:Button id="createPostButton" class="btn btn-primary my-3" Text="New Post" runat="server" OnClick="CreatePostButtonClick" />
                            <div id="createPostResult" class="card-footer text-muted" runat="server">
                        </div>
                    </div>
                </div>
            </div>
        </main>

        <!-- footer section -->
        <footer class="text-center text-lg-start bg-light text-muted mt-4">

          <!-- social medias -->
          <section class="d-flex justify-content-center justify-content-lg-between px-4 py-3 border-bottom">
            <div class="me-5 d-none d-md-block">
              <span>Get connected with us on social networks:</span>
            </div>
            <div>
              <a href="https://www.twitter.com/hasan5afari" class="me-4 text-reset text-decoration-none">
                <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor" class="bi bi-twitter" viewBox="0 0 16 16">
                  <path d="M5.026 15c6.038 0 9.341-5.003 9.341-9.334 0-.14 0-.282-.006-.422A6.685 6.685 0 0 0 16 3.542a6.658 6.658 0 0 1-1.889.518 3.301 3.301 0 0 0 1.447-1.817 6.533 6.533 0 0 1-2.087.793A3.286 3.286 0 0 0 7.875 6.03a9.325 9.325 0 0 1-6.767-3.429 3.289 3.289 0 0 0 1.018 4.382A3.323 3.323 0 0 1 .64 6.575v.045a3.288 3.288 0 0 0 2.632 3.218 3.203 3.203 0 0 1-.865.115 3.23 3.23 0 0 1-.614-.057 3.283 3.283 0 0 0 3.067 2.277A6.588 6.588 0 0 1 .78 13.58a6.32 6.32 0 0 1-.78-.045A9.344 9.344 0 0 0 5.026 15z"/>
                </svg>
              </a>
              <a href="https://t.me/hasan5afari" class="me-4 text-reset text-decoration-none">
                <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor" class="bi bi-telegram" viewBox="0 0 16 16">
                  <path d="M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0zM8.287 5.906c-.778.324-2.334.994-4.666 2.01-.378.15-.577.298-.595.442-.03.243.275.339.69.47l.175.055c.408.133.958.288 1.243.294.26.006.549-.1.868-.32 2.179-1.471 3.304-2.214 3.374-2.23.05-.012.12-.026.166.016.047.041.042.12.037.141-.03.129-1.227 1.241-1.846 1.817-.193.18-.33.307-.358.336a8.154 8.154 0 0 1-.188.186c-.38.366-.664.64.015 1.088.327.216.589.393.85.571.284.194.568.387.936.629.093.06.183.125.27.187.331.236.63.448.997.414.214-.02.435-.22.547-.82.265-1.417.786-4.486.906-5.751a1.426 1.426 0 0 0-.013-.315.337.337 0 0 0-.114-.217.526.526 0 0 0-.31-.093c-.3.005-.763.166-2.984 1.09z"/>
                </svg>
              </a>
            </div>
          </section>
          <!-- Section: Social media -->
    
          <!-- Section: Links  -->
          <section class="">
            <div class="container text-center text-md-start mt-4">
              <!-- Grid row -->
              <div class="row mt-3">
                <!-- Grid column -->
                <div class="col-md-3 col-lg-4 col-xl-3 mx-auto mb-4">
                  <!-- Content -->
                  <h6 class="text-uppercase fw-bold mb-4">
                    <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor" class="bi bi-building" viewBox="0 0 16 16">
                      <path fill-rule="evenodd" d="M14.763.075A.5.5 0 0 1 15 .5v15a.5.5 0 0 1-.5.5h-3a.5.5 0 0 1-.5-.5V14h-1v1.5a.5.5 0 0 1-.5.5h-9a.5.5 0 0 1-.5-.5V10a.5.5 0 0 1 .342-.474L6 7.64V4.5a.5.5 0 0 1 .276-.447l8-4a.5.5 0 0 1 .487.022zM6 8.694 1 10.36V15h5V8.694zM7 15h2v-1.5a.5.5 0 0 1 .5-.5h2a.5.5 0 0 1 .5.5V15h2V1.309l-7 3.5V15z"/>
                      <path d="M2 11h1v1H2v-1zm2 0h1v1H4v-1zm-2 2h1v1H2v-1zm2 0h1v1H4v-1zm4-4h1v1H8V9zm2 0h1v1h-1V9zm-2 2h1v1H8v-1zm2 0h1v1h-1v-1zm2-2h1v1h-1V9zm0 2h1v1h-1v-1zM8 7h1v1H8V7zm2 0h1v1h-1V7zm2 0h1v1h-1V7zM8 5h1v1H8V5zm2 0h1v1h-1V5zm2 0h1v1h-1V5zm0-2h1v1h-1V3z"/>
                    </svg>
                    &nbsp;
                    FakeHN
                  </h6>
                  <p>
                    Simple share your thoughts !
                    To learn more about FakeHN go to About page.
                  </p>
                </div>
                <!-- Grid column -->
  
                <!-- Grid column -->
                <div class="col-md-4 col-lg-3 col-xl-3 mx-auto mb-md-0 mb-4">
                  <!-- Links -->
                  <h6 class="text-uppercase fw-bold mb-4"> Contact </h6>
                  <p> 
                    <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor" class="bi bi-geo" viewBox="0 0 16 16">
                      <path fill-rule="evenodd" d="M8 1a3 3 0 1 0 0 6 3 3 0 0 0 0-6zM4 4a4 4 0 1 1 4.5 3.969V13.5a.5.5 0 0 1-1 0V7.97A4 4 0 0 1 4 3.999zm2.493 8.574a.5.5 0 0 1-.411.575c-.712.118-1.28.295-1.655.493a1.319 1.319 0 0 0-.37.265.301.301 0 0 0-.057.09V14l.002.008a.147.147 0 0 0 .016.033.617.617 0 0 0 .145.15c.165.13.435.27.813.395.751.25 1.82.414 3.024.414s2.273-.163 3.024-.414c.378-.126.648-.265.813-.395a.619.619 0 0 0 .146-.15.148.148 0 0 0 .015-.033L12 14v-.004a.301.301 0 0 0-.057-.09 1.318 1.318 0 0 0-.37-.264c-.376-.198-.943-.375-1.655-.493a.5.5 0 1 1 .164-.986c.77.127 1.452.328 1.957.594C12.5 13 13 13.4 13 14c0 .426-.26.752-.544.977-.29.228-.68.413-1.116.558-.878.293-2.059.465-3.34.465-1.281 0-2.462-.172-3.34-.465-.436-.145-.826-.33-1.116-.558C3.26 14.752 3 14.426 3 14c0-.599.5-1 .961-1.243.505-.266 1.187-.467 1.957-.594a.5.5 0 0 1 .575.411z"/>
                    </svg>
                  Iran, CHB, Hafshejan .
                  </p>
                  <p> 
                    <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor" class="bi bi-envelope" viewBox="0 0 16 16">
                      <path d="M0 4a2 2 0 0 1 2-2h12a2 2 0 0 1 2 2v8a2 2 0 0 1-2 2H2a2 2 0 0 1-2-2V4Zm2-1a1 1 0 0 0-1 1v.217l7 4.2 7-4.2V4a1 1 0 0 0-1-1H2Zm13 2.383-4.708 2.825L15 11.105V5.383Zm-.034 6.876-5.64-3.471L8 9.583l-1.326-.795-5.64 3.47A1 1 0 0 0 2 13h12a1 1 0 0 0 .966-.741ZM1 11.105l4.708-2.897L1 5.383v5.722Z"/>
                    </svg>
                  10Hasansafari@gmail.com
                  </p>
                </div>
                <!-- Grid column -->
              </div>
              <!-- Grid row -->
            </div>
          </section>
          <!-- Section: Links  -->
    
          <div class="text-center p-4" style="background-color: rgba(0, 0, 0, 0.03);">
            © 2021 Copyright:
            <a class="text-reset fw-bold" href="https://www.normalperson.ir/">normalperson.ir</a>
          </div>
        </footer>
    </form>

    <!-- scripts -->
    <script src="scripts/jquery.js"></script>
    <script src="scripts/bootstrap.min.js"></script>
    <script src="scripts/main.js"></script>
</body>
</html>
