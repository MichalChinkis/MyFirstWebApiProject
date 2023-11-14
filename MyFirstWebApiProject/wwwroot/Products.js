const fetchProducts = async (url='') => {
    try {
        const response = await fetch(`/api/Products${url}`,
            {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json'
                }
            })

        const products = await response.json()
        alert("products", products);
        console.log("products", products);
        for (var i = 0; i < products.length; i++) {
            drawProduct(products[i]);
        }
    } catch (error) { alert(error, "error") }
    
}

const drawProduct = (product) => {
    temp = document.getElementById("temp-card");
    var clonProducts = temp.content.cloneNode(true);
    clonProducts.querySelector("img").src = product.picture;
    clonProducts.querySelector("h1").innerText = product.productName;
    clonProducts.querySelector(".price").innerText = product.price + "$";
    clonProducts.querySelector(".description").innerText = product.description;
    clonProducts.querySelector("button").addEventListener("click", () => {
        alert("added try")
        //פונקציה של הוספה לסל
    });
    document.getElementById("ProductList").appendChild(clonProducts);
}

function filterProducts() {
    var description = document.getElementById('nameSearch').value;
    const url = `?desc=${encodeURIComponent(description)}`;
    document.getElementById("ProductList").innerHTML = "";
    fetchProducts(url);
}


