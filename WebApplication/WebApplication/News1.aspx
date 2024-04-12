<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="News1.aspx.cs" Inherits="WebApplication.News1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <title>Google News RSS Feed</title>
    <link rel="stylesheet" href="Styles/style.css" />
   <%-- <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>--%>
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/script.js"></script>
    
</head>
<body>
    <form id="form1" runat="server">
       
        <div class="container"> 
             <div class="column" id="newsTopics">
                 <h1>News Topics</h1>
                 <asp:Repeater ID="rptTopics" runat="server">
                     <ItemTemplate>
                         <div class="topic" data-post-id='<%# Eval("Id") %>'>
                             <h2><%# Eval("Title") %></h2>
                         </div>
                     </ItemTemplate>
                 </asp:Repeater>
             </div>

        <div class="column">
             <div class="postDetails" >
                 <h1>post</h1>
                 <h2 class="postTitle"></h2>
                 <div class="postBody"> </div>
                 <a href="#" class="postLink">Read More</a>
             </div>
        
                
        </div>

        </div>
    </form>
</body>
</html>
