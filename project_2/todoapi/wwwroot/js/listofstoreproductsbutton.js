window.addEventListener("load", addhandlestoreproducts);

function addhandlestoreproducts() {
	console.log(sessionStorage);
	//fetch("Products/Productlist")
	fetch(`api/Products/ProductsbyStore/${sessionStorage.StoreId}`)
		.then(res => res.json())
		.then(data => {
			console.log(data)
			const lop = document.querySelector('.listofstoreproductsbutton');

			for (let x = 0; x < data.length; x++) {
				var counter2 = 0;
				if (sessionStorage.getItem('productid' + data[x].productId))
					counter2 = parseInt(sessionStorage.getItem('productid' + data[x].productId));
				else
					counter2 = 0;
			
				
				if ((data[x].productQuantity - counter2) <= 0) {
					lop.innerHTML += `


							<div class="card-footer p-4 pt-0 border-top-0 bg-transparent outofstock">
								<div class="text-center outofstock"><div class="btn btn-outline-dark mt-auto disabled outofstock "><div id="outofstock">Out of Stock</div></div></div>


							</div>`
						

			

				}
				else {
					lop.innerHTML += `
			           
			                    
			                     <div class="card-footer p-4 pt-0 border-top-0 bg-transparent outofstock" onmouseover="sessionStorage.ProductPrice=${data[x].productPrice}">
                <div class="text-center outofstock"><a class="btn btn-outline-dark mt-auto  " href="Store.html"><div id="${data[x].productId}" onClick="sessionStorage.productid=${data[x].productId}">Add To Cart</div></a></div>

			               
			             </div>`;
				}

			}



		});

};
