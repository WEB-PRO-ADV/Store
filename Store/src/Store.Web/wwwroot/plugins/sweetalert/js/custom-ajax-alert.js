function AddItem(code, price) {
  swal(
    {
      title: "Add New Product",
      text: "Original price is: " + price,
      type: "input",
      showCancelButton: !0,
      closeOnConfirm: !1,
      inputPlaceholder: "Enter your price",
    },
    function (e) {
      if (!1 !== e) {
        if ("" === e || isNaN(e)) {
          swal.showInputError("Please provide a valid price!");
          return !1;
        } else {
          $.ajax({
            url: "/admin/SupplierProducts/Add",
            type: "POST",
            data: { code: code, price: e },
            success: function (data) {
                void swal("Done", "You Added product #" + code, "success");
                $.ajax({
                    url: "/admin/SupplierProducts/ChangeProductStatus",
                    type: "POST",
                    data: { code: code, price: e, isAdded: true },
                    success: function (data) {
                        $("#add-remove").html(data);
                    },
                });
                return 1;
            },
            error: function () {
              void swal(
                "Error",
                "Something went wrong, try again later!",
                "error"
              );
              return 1;
            },
          });
        }
      } else {
        return !1;
      }
    }
  );
}

function RemoveItem(code) {
    swal(
        {
            title: "Are you sure to delete ?",
            text: "This item and all offers that contain it will be removed!!",
            type: "warning",
            showCancelButton: !0,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "Yes, delete it !!",
            cancelButtonText: "No, cancel it !!",
            closeOnConfirm: !1,
            closeOnCancel: !1,
        },
        function (e) {
            if(e) {
                $.ajax({
                    url: "/admin/SupplierProducts/Remove",
                    type: "POST",
                    data: { code: code, price: e },
                    success: function (data) {
                        swal(
                            "Removed !!",
                            "You removed the item from the store successfully !!",
                            "success"
                        );
                        $.ajax({
                            url: "/admin/SupplierProducts/ChangeProductStatus",
                            type: "POST",
                            data: { code: code, price: e, isAdded: false },
                            success: function (data) {
                                $("#add-remove").html(data);
                            },
                        });
                        return 1;
                    },
                    error: function () {
                        swal(
                            "Error",
                            "Something went wrong, try again later!",
                            "error"
                          );
                        return 0;
                    },
                  });
            }
            else {
                swal("Cancelled !!", "You cancelled removing the item successfully !!", "error");
                return 0;
            }
        }
      );
}


function deleteItem(id) {
    swal(
        {
            title: "Are you sure to delete ?",
            text: "This item and all offers that contain it will be removed!!",
            type: "warning",
            showCancelButton: !0,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "Yes, delete it !!",
            cancelButtonText: "No, cancel it !!",
            closeOnConfirm: !1,
            closeOnCancel: !1,
        },
        function (e) {
            if (e) {
                $.ajax({
                    url: "/admin/Items/Delete",
                    type: "POST",
                    data: { id: id },
                    success: function (data) {
                        swal(
                            "Removed !!",
                            "You removed the item from the store successfully !!",
                            "success"
                        );
                        $("#table-row-" + id).remove();
                        return 1;
                    },
                    error: function () {
                        swal(
                            "Error",
                            "Something went wrong, try again later!",
                            "error"
                        );
                        return 0;
                    },
                });
            }
            else {
                swal("Cancelled !!", "You cancelled removing the item successfully !!", "error");
                return 0;
            }
        }
    );
}

function deleteOffer(id) {
    swal(
        {
            title: "Are you sure to delete ?",
            text: "This Offer will be removed!!",
            type: "warning",
            showCancelButton: !0,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "Yes, delete it !!",
            cancelButtonText: "No, cancel it !!",
            closeOnConfirm: !1,
            closeOnCancel: !1,
        },
        function (e) {
            if (e) {
                $.ajax({
                    url: "/admin/Offers/Delete",
                    type: "POST",
                    data: { id: id },
                    success: function (data) {
                        swal(
                            "Removed !!",
                            "You removed the offer from the store successfully !!",
                            "success"
                        );
                        $("#table-row-" + id).remove();
                        return 1;
                    },
                    error: function () {
                        swal(
                            "Error",
                            "Something went wrong, try again later!",
                            "error"
                        );
                        return 0;
                    },
                });
            }
            else {
                swal("Cancelled !!", "You cancelled removing the offer successfully !!", "error");
                return 0;
            }
        }
    );
}