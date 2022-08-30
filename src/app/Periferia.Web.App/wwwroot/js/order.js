// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

const calculate = (a, b, c) => {

    var i = a.dataset.ix;

    const orderProductModelTotal = document.querySelector(`#OrderProductModel_${i}__Total`);
    const orderProductModelPrice = document.querySelector(`#OrderProductModel_${i}__Price`);
    const orderModelTotal = document.querySelector("#OrderModel_Total");
    const inputTotal = document.querySelector("#input_Total");
    const spanTotal = document.querySelector(`#span_${i}__Total`);

    const quantity = a.value;
    const price = orderProductModelPrice.value;
    const subtotal1 = orderProductModelTotal.value;
    const subtotal2 = quantity * price;

    let current = orderModelTotal.value || 0;
    current -= subtotal1;

    inputTotal.value = Number(current).toFixed(2);
    orderModelTotal.value = Number(current).toFixed(2);

    current += subtotal2;

    orderProductModelTotal.value = Number(subtotal2).toFixed(2);
    spanTotal.innerText = Number(subtotal2).toFixed(2);

    inputTotal.value = Number(current).toFixed(2);
    orderModelTotal.value = Number(current).toFixed(2);
};