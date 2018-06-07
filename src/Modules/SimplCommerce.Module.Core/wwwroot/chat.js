// The following sample code uses modern ECMAScript 6 features 
// that aren't supported in Internet Explorer 11.
// To convert the sample for environments that do not support ECMAScript 6, 
// such as Internet Explorer 11, use a transpiler such as 
// Babel at http://babeljs.io/. 
//
// See Es5-chat.js for a Babel transpiled version of the following code:

        $(document).ready(function () {

            var  connection;

            $("#chat_input").hide();
            
            $(".chat-close").click(function () {
                $(".chat").slideToggle();
            });

            $("#chat_start").click(function () {

                console.log("start clicked");

                $("#chat_intro").hide(1000);

                $("#chat_input").show(1000);

                connection = new signalR.HubConnectionBuilder()
                    .withUrl("/ChatHub")
                    .build();

                connection.on("ReceiveMessage", (user, message) => {
                    const encodedMsg = user + " says " + message;
                    const li = document.createElement("li");
                    li.textContent = encodedMsg;
                    document.getElementById("messagesList").appendChild(li);
                });


                //document.getElementById("sendButton").addEventListener("click", event => {
                //    const user = document.getElementById("userName").value;
                //    const message = document.getElementById("messageInput").value;
                //    connection.invoke("SendMessage", user, message).catch(err => console.error(err.toString()));
                //    event.preventDefault();
                //});

                connection.start().catch(err => console.error(err.toString()));
               
            
            });


            $("#sendButton").click(function () {
                
                const user = $("#userName").val();
                const email = $("#userEmail").val();
                const message = $("#messageInput").val(); //document.getElementById("messageInput").value;
                 connection.invoke("SendMessage", user, message).catch(err => console.error(err.toString()));
                    event.preventDefault();

            });
            

        });

