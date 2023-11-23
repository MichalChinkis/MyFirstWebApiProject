const drawCart = () => {
    var arr = JSON.parse(sessionStorage.getItem("cart"));
    var sum = 0;
    for (var i = 0; i < arr.length; i++) {
        temp = document.getElementById("temp-row");
        var clonProduct = temp.content.cloneNode(true);
        clonProduct.querySelector(".image").src = arr[i].picture;
        clonProduct.querySelector(".itemName").innerText = arr[i].productName;
        clonProduct.querySelector(".price").innerText = arr[i].price + "$";
        clonProduct.querySelector(".totalColumn delete").addEventListener("click", () => {
            arr.splice(i, 1);
            sessionStorage.setItem(JSON.stringify(arr));
            drawCart();
        });
        sum++;
        document.getElementById("items").appendChild(clonProduct);
    }
    document.getElementById(".itemCount").innerText = arr.length;
    document.getElementById(".totalAmount").innerText = sum;
}