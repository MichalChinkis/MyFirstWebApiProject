
const checkPassword = () => {
    
    var strength = {
        0: "Worst",
        1: "Bad",
        2: "Weak",
        3: "Good",
        4: "Strong"
    }
    var password = document.getElementById("passInput").value;
    var progress = document.getElementById("password-strength-progress");
    var text = document.getElementById('password-strength-text');

        var result = zxcvbn(password);
    if (result.score <= 2) {
        alert("your password is weak!! try again")
        document.getElementById("passInput").innerHTML=""
    }
    // Update the password strength progress
    progress.value = result.score;

    // Update the text indicator
     if (password !== "") {
            text.innerHTML = "Strength: " + strength[result.score];
        } else {
            text.innerHTML = "";
        }
}

const registerFunc =  async () => {
    const user = {

        Email: document.getElementById("emailInput").value,
        LastName: document.getElementById("lnInput").value,
        FirstName: document.getElementById("fnInput").value,
        UserName: document.getElementById("usInput").value,
        Password: document.getElementById("passInput").value
    }

    try {
        const response = await fetch('/api/Users',
            {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(user)
            })
        if (response.status!=200)
            alert("not added")
        else {
            const DataPost = await response.json()
            alert("success")
        }
    } catch (error) { alert(error, "error") }
}


const loginFunc = async () => {

    try {
        const response = await fetch(`/api/Users/?UserName=${document.getElementById("usLogiInput").value}&Password=${document.getElementById("passLoginInput").value}`)
        if (response.NoContent) alert("not found")
        if (!response.ok) {
            alert("not found")
            return;
        }
             else {
                 const resUser = await response.json()
            alert("success")
            console.log("user", resUser);
            sessionStorage.setItem("user", JSON.stringify(resUser));
            window.location.href="Products.html"

        }
    } catch (error) { alert(error) }
}

const updateFunc = async () => {
    const user = {
        Email: document.getElementById("emailInput").value,
        LastName: document.getElementById("lnInput").value,
        FirstName: document.getElementById("fnInput").value,
        UserName: document.getElementById("usInput").value,
        Password: document.getElementById("passInput").value
    }

    try {
        const id = (JSON.parse(sessionStorage.getItem("user"))).id
        const response = await fetch(`/api/users/${id}`,
            {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(user)
            })
        if (!response.ok)
            alert("not found")
        else {
            //const DataPost = await response.json()
            alert("success")
        }
    } catch (error) { alert(error, "error") }

}

