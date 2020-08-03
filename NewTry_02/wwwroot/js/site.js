// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

import { signalR } from "../lib/dist/browser/signalr";

// Write your Javascript code.

//$(() => {
//    let connection = new signalR.HubConnectionBuilder().withUrl("/signalServer").build()
//    connection.start()

//    connection.on("refreshProducts", function (){
//        loadData()
//    })
//    loadData();

//    function loadData() {
//        var tr = ''
//        $.ajax({
//            url: '/Pages/GetProducts',
//            method: 'Get',
//            success: (result) => {
//                $.each(result, (k, v) => {
//                    tr = tr + `<tr>
//                        <td>${v.id}</td>
//                        <td>${v.productName}</td>
//                        <td>${v.quantity}</td>
//                        <td>${v.unitPrice}</td>
//                    `
//                })

//                $("#tableBody").html(tr)
//            },
//            error: (error) => {
//                console.log(error);
//            }
//        })
//    }
//})
