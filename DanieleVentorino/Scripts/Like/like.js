
var url = "http://localhost:51920/api/";

$(() => {

    //update button text and count
     updateButton();    

    //like / unlike
    $(".likebutton").on("click", function (e) {
        e.preventDefault();

        let button = $(this);

       
        let data = {
            PageName: pageName, UserName: userName
        };

        if ($(button).data("like") == true)
        {
            setUnlike(button);
            data.IsLike = true;

            $.ajax({
                type: "POST",
                data: data,
                url: url + "like"
            })
            .success(response => likeSuccess(response, button))
            .error(response => {

                setLike(button);
                alert("server error :(");
            });
        }
        else {

            setLike(button)
            data.IsLike = false;

            $.ajax({
                type: "POST",
                data: data,
                url: url + "like"
            })
            .success(response => likeSuccess(response, button))
            .error(response => {

                setUnlike(button);
                alert("server error :(");
            });
        }

        
    });
})


function likeSuccess(response, button) {

    if (response.Status == "success" && response.JSON.updated) {
        let count = response.JSON.count;

        $(button).find(".count").text(count);
    }
}

function setLike(element) {
    
    $(element).data("like", true);
    $(element).find(".text").text("Like!");
}

function setUnlike(element) {

    $(element).data("like", false);
    $(element).find(".text").text("Unlike");
}

function setLikeCount(count) {
    
    $(".likebutton").find(".count").text(count);
}

function updateButton() {

    $.ajax({
        type: "GET",
        url: url + "like/" + pageName
    }).success((response) => {

        if(response.Status == "success")
        {
            let list = response.JSON.userNameList;

            //update like count
            setLikeCount(list.length);

            //set like/unlike button
            if(list.indexOf(userName) > -1)
            {
                setUnlike($(".likebutton"));    
            }
            else
            {
                setLike($(".likebutton"));
            }
        }
        else {

            alert("could not get list");
        }
        
    }).error((response) => {
        
        alert("server error :(");
    });
}