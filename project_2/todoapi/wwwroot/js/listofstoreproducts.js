window.addEventListener("load", addhandlestoreproducts);

function addhandlestoreproducts() {
    console.log(sessionStorage);
    //fetch("Products/Productlist")
    fetch(`api/Products/ProductsbyStore/${sessionStorage.StoreId}`)
        .then(res => res.json())
        .then(data => {
            console.log(data)
            const lop = document.querySelector('.listofstoreproducts');

            for (let x = 0; x < data.length; x++) {
                var counter2 = 0;
                if (sessionStorage.getItem('productid' + data[x].productId))
                    counter2 = parseInt(sessionStorage.getItem('productid' + data[x].productId));
                else
                    counter2 = 0;
              if ((data[x].productQuantity - counter2) <= 0) {
                    lop.innerHTML += `
<div class="col mb-5 outofstock">
    <div class="card h-100 outofstock">

        <div class="card-body p-4 outofstock">
            <div class="text-center outofstock">
                <!-- Product name-->
                <h5 class="fw-bolder outofstock">${data[x].productName}</h5>
                <h5 class="fw-bolder outofstock">Quantity Left: ${data[x].productQuantity - counter2}</h5>
                <h2 class="fw-bolder outofstock">$${data[x].productPrice}</h2>
                <!-- Product price-->
                ${data[x].productDescription}
            </div>
        </div>

        <div class="card-footer p-4 pt-0 border-top-0 bg-transparent outofstock">
            <div class="text-center outofstock">
                <div class="btn btn-outline-dark mt-auto disabled outofstock ">
                    <div id="outofstock">Out of Stock</div>
                </div>
            </div>


        </div>
    </div>
</div>`;




                } else {
                  
                    lop.innerHTML += `
<div class"div2"   onmouseover="sessionStorage.setItem('productid','${data[x].productId}')">
   <div class"div2"  onmouseover="sessionStorage.setItem('ProductName','${data[x].productName}')">
      <div class"div2" onmouseover="sessionStorage.setItem('ProductPrice','${data[x].productPrice}')">
         <div class"div2"  onclick="sessionStorage.setItem('ProductName','${data[x].productName}')">
            <div class"div2" onclick="sessionStorage.setItem('productid','${data[x].productId}')">
               <div class"div2" onclick="sessionStorage.setItem('ProductPrice','${data[x].productPrice}')">
                  <div class="col mb-5 outofstock" >
                     <div class="card col-lg-12 d-flex align-items-stretch  outofstock" >
                        <div class="card-body p-4 outofstock" >
                           <div class="text-center outofstock">
                              <!-- Product name-->
                              <h5 class="fw-bolder outofstock">${data[x].productName}</h5>
                              <h5 class="fw-bolder outofstock">Quantity Left: ${data[x].productQuantity - counter2}</h5>
                              <!-- Product price-->
                              <h2 class="fw-bolder outofstock">$${data[x].productPrice}</h2>
                              ${data[x].productDescription}
                           </div>
                        </div>
                        <div class="card-footer p-4 pt-0 border-top-0 bg-transparent outofstock" ">
                           <div class=" text-center outofstock">
                              <a class="btn btn-outline-dark mt-auto  " href="Store.html">
                                 <div id="${data[x].productId}" onClick="sessionStorage.productid=${data[x].productId}">Add To Cart</div>
                              </a>
                           </div>
                        </div>
                     </div>
                  </div>
               </div>
            </div>
         </div>
      </div>
   </div>
</div>`;
                }

            }



        });

};