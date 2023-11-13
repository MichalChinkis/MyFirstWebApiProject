drawProduct = (product) => {
    tempProduct = document.getElementById("temp-prod");
    var clonProduct = tempProduct.contect.cloneNode(true);
    clonProduct.querySelector("img").src = product.picture;
    clonProduct.querySelector("h1").innerText = product.productName;
    clonProduct.querySelector(".price").innerText = product.price + "$";
    clonProduct.querySelector(".description").innerText = product.description;
    clonProduct.querySelector("button").addEventListener("click", () => {
        alert("added try")
        //פונקציה של הוספה לסל
    });
    document.getElementById("productList").appendChild(clonProduct);
}