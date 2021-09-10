$(document).ready(function () {
    var chk = 1;
    /*---------------------------------------------------------*/


    $(".next_btn").click(function () {

        //start panel 1
        //start 1.Core or Critical Tiger Habitat (CTH)

        //if ($("#contentbody_DdlNotified1_a").val() == "Yes") {

        //    var fromDate = new Date();
        //    var txtFromDate = $("#contentbody_TxtDateNotification1_b").val();
        //    var FromDate = txtFromDate.split("/");
        //    /*Start 'Date to String' conversion block, this block is required because javascript do not provide any direct function to convert 'String to Date' */
        //    var fdd = FromDate[0]; //get the day part
        //    var fmm = FromDate[1]; //get the month part
        //    var fyyyy = FromDate[2]; //get the year part contentbody_HiddenField2
        //    fromDate.setUTCDate(fdd);
        //    fromDate.setUTCMonth(fmm - 1);
        //    fromDate.setUTCFullYear(fyyyy);
        //    var toDate = new Date();
        //    var txtToDate = $("#contentbody_HiddenField2").val();;
        //    var ToDate = txtToDate.split("/");
        //    var tdd = ToDate[0]; //get the day part
        //    var tmm = ToDate[1]; //get the month part
        //    var tyyyy = ToDate[2]; //get the year part
        //    toDate.setUTCDate(tdd);
        //    toDate.setUTCMonth(tmm - 1);
        //    toDate.setUTCFullYear(tyyyy);
        //    //end of 'String to Date' conversion block
        //    var difference = toDate.getTime() - fromDate.getTime();
        //    var daysDifference = Math.floor(difference / 1000 / 60 / 60 / 24);

        //    //     alert('df');
        //    difference -= daysDifference * 1000 * 60 * 60 * 24;

        //    //    //if diffrence is greater then 366 then invalidate, else form is valid
        //    // if(difference > 366 )
        //    if (daysDifference < 0) {
        //        alert("Don't enter future date of Title [1.Core or Critical Tiger Habitat (CTH)], Child label of [Date of Notification]");
        //        $("#contentbody_TxtDateNotification1_b").focus();
        //        chk = 0;

        //        return false;
        //    }

        //}

        if ($("#contentbody_DdlNotified1_a").val() == "Yes") {

            if ($("#contentbody_TxtDateNotification1_b").val() == "") {
                alert("Please enter of Title [1.Core or Critical Tiger Habitat (CTH)], Child label of [Date of Notification]");
                $("#contentbody_TxtDateNotification1_b").focus();
                chk = 0;
                return false;
            }
        }
        //---

        if ($("#contentbody_TxtAreaHa1_c").val() == "") {
            alert("Please enter of Title [1.Core or Critical Tiger Habitat (CTH)], Child label of [Area(Ha.)]");
            $("#contentbody_TxtAreaHa1_c").focus();
            chk = 0;
            return false;
        }
        if ($("#contentbody_TxtAreaHa1_c").val() != "") {
            var inputVal = $("#contentbody_TxtAreaHa1_c").val();
            // alert(inputVal);
            var numericReg = /^\d+(?:\.\d\d?)?$/;
            if (!numericReg.test(inputVal)) {
                alert("Please enter of Title [1.Core or Critical Tiger Habitat (CTH)], Child label of [Area(Ha.)] for needed to match number to 2 decimal places");
                $("#contentbody_TxtAreaHa1_c").focus();
                chk = 0;
                return false;
            }
        }
        //---
        if ($("#contentbody_TxtCompliance1_d").val() == "") {
            alert("Please enter of Title [1.Core or Critical Tiger Habitat (CTH)], Child label of [Compliance of section 38V of the Wildlife(Protection) Act, 1972]");
            $("#contentbody_TxtCompliance1_d").focus();
            chk = 0;
            return false;
        }
        if ($("#contentbody_TxtCompliance1_d").val() != "") {
            var inputVal = $("#contentbody_TxtCompliance1_d").val();
            //alert(inputVal);
            var numericReg = /^\s*[a-zA-Z0-9,\s]+\s*$/;
            if (!numericReg.test(inputVal)) {
                alert("Please enter of Title [1.Core or Critical Tiger Habitat (CTH)], Child label of [Compliance of section 38V of the Wildlife(Protection) Act, 1972]  for No special characters allowed");
                $("#contentbody_TxtCompliance1_d").focus();
                chk = 0;
                return false;
            }
        }
        //end 1.Core or Critical Tiger Habitat (CTH)

        //start 2.Buffer or Peripheral Area
        if ($("#contentbody_DdlNotified2_a").val() == "Yes") {
            if ($("#contentbody_TxtDateNotification2_b").val() == "") {
                alert("Please enter of Title [2.Buffer or Peripheral Area], Child label of [Date of Notification]");
                $("#contentbody_TxtDateNotification2_b").focus();
                chk = 0;
                return false;
            }
        }
        //---
        if ($("#contentbody_TxtAreaHa2_c").val() == "") {
            alert("Please enter of Title [2.Buffer or Peripheral Area], Child label of [Area(Ha.)]");
            $("#contentbody_TxtAreaHa2_c").focus();
            chk = 0;
            return false;
        }
        if ($("#contentbody_TxtAreaHa2_c").val() != "") {
            var inputVal = $("#contentbody_TxtAreaHa2_c").val();
            // alert(inputVal);
            var numericReg = /^\d+(?:\.\d\d?)?$/;
            if (!numericReg.test(inputVal)) {
                alert("Please enter of Title [2.Buffer or Peripheral Area], Child label of [Area(Ha.)] for needed to match number to 2 decimal places");
                $("#contentbody_TxtAreaHa2_c").focus();
                chk = 0;
                return false;
            }
        }
        //---
        if ($("#contentbody_DdlExpertCommittee2_d").val() == "Yes") {
            if ($("#contentbody_TxtDateConstitution2_e").val() == "") {
                alert("Please enter of Title [2.Buffer or Peripheral Area], Child label of [Date of Constitution]");
                $("#contentbody_TxtDateConstitution2_e").focus();
                chk = 0;
                return false;
            }
        }
        //---
        if ($("#contentbody_DdlConsultationGramSabha2_f").val() == "Yes") {
            if ($("#contentbody_TxtNameGramSabha2_g").val() == "") {
                alert("Please enter of Title [2.Buffer or Peripheral Area], Child label of [Name of Gram Sabha]");
                $("#contentbody_TxtNameGramSabha2_g").focus();
                chk = 0;
                return false;
            }
        }
        if ($("#contentbody_TxtNameGramSabha2_g").val() != "") {
            var inputVal = $("#contentbody_TxtNameGramSabha2_g").val();
            //alert(inputVal);/^\s*[a-zA-Z0-9,\s]+\s*$/;
            var numericReg = /^\s*[a-zA-Z,\s]+\s*$/;
            if (!numericReg.test(inputVal)) {
                alert("Please enter of Title [2.Buffer or Peripheral Area], Child label of [Name of Gram Sabha]  for No special characters and number allowed");
                $("#contentbody_TxtNameGramSabha2_g").focus();
                chk = 0;
                return false;
            }
        }
        if ($("#contentbody_FileUploadMapCTH2_h").val() != "") {
            var inputVal = $("#contentbody_FileUploadMapCTH2_h").val();
            //alert(inputVal);
            //var numericReg = /^.*\.(jpg|jpeg|png|gif)$/;
            var numericReg = /^.*\.(jpg|jpeg|pdf)$/;
            if (!numericReg.test(inputVal)) {
                alert("Please enter of Title [2.Buffer or Peripheral Area], Child label of [Map of CTH & Buffer or Peripheral Area.(jpg or .pdf files only)]  only allow jpg and pdf");
                $("#contentbody_FileUploadMapCTH2_h").focus();
                chk = 0;
                return false;
            }

        };
        if ($("#contentbody_FileUploadUploadfile2_i").val() != "") {
            var inputVal = $("#contentbody_FileUploadUploadfile2_i").val();
            //alert(inputVal);
            //var numericReg = /^.*\.(jpg|jpeg|png|gif)$/;
            var numericReg = /^.*\.(pdf)$/;
            if (!numericReg.test(inputVal)) {
                alert("Please enter of Title [2.Buffer or Peripheral Area], Child label of [Upload file]  only allow pdf");
                $("#contentbody_FileUploadUploadfile2_i").focus();
                chk = 0;
                return false;
            }

        };
        if ($("#contentbody_FileUploadUploadfile2_j").val() != "") {
            var inputVal = $("#contentbody_FileUploadUploadfile2_j").val();
            //alert(inputVal);
            //var numericReg = /^.*\.(jpg|jpeg|png|gif)$/;
            var numericReg = /^.*\.(pdf)$/;
            if (!numericReg.test(inputVal)) {
                alert("Please enter of Title [2.Buffer or Peripheral Area], Child label of [Upload file]  only allow pdf");
                $("#contentbody_FileUploadUploadfile2_j").focus();
                chk = 0;
                return false;
            }

        };
        if ($("#contentbody_FileUploadCompleted3_a").val() != "") {
            var inputVal = $("#contentbody_FileUploadCompleted3_a").val();
            //alert(inputVal);
            //var numericReg = /^.*\.(jpg|jpeg|png|gif)$/;
            var numericReg = /^.*\.(pdf)$/;
            if (!numericReg.test(inputVal)) {
                alert("Please enter of Title [3.Recognition / Determination/ Acquisition / Vesting of Forest Rights of Schedule Tribes & such other Traditional Forest Dwellers], Child label of [Completed]  only allow pdf");
                $("#contentbody_FileUploadCompleted3_a").focus();
                chk = 0;
                return false;
            }

        };
        if ($("#contentbody_FileUpload6_a").val() != "") {
            var inputVal = $("#contentbody_FileUpload6_a").val();
            //alert(inputVal);
            //var numericReg = /^.*\.(jpg|jpeg|png|gif)$/;
            var numericReg = /^.*\.(pdf)$/;
            if (!numericReg.test(inputVal)) {
                alert("Please enter of Title [6.Voluntary consent of individuals affected], Child label of [Obtained ]  only allow pdf");
                $("#contentbody_FileUpload6_a").focus();
                chk = 0;
                return false;
            }

        };
        if ($("#contentbody_FileUploadProvided7_a").val() != "") {
            var inputVal = $("#contentbody_FileUploadProvided7_a").val();
            //alert(inputVal);
            //var numericReg = /^.*\.(jpg|jpeg|png|gif)$/;
            var numericReg = /^.*\.(pdf)$/;
            if (!numericReg.test(inputVal)) {
                alert("Please enter of Title [7.Facilities & Land Allocation At The Resettlement Location], Child label of [Provided  ]  only allow pdf");
                $("#contentbody_FileUploadProvided7_a").focus();
                chk = 0;
                return false;
            }

        };
        if ($("#contentbody_FileUpload8_a_a").val() != "") {
            var inputVal = $("#contentbody_FileUpload8_a_a").val();
            //alert(inputVal);
            //var numericReg = /^.*\.(jpg|jpeg|png|gif)$/;
            var numericReg = /^.*\.(pdf)$/;
            if (!numericReg.test(inputVal)) {
                alert("Please enter of Title [8.Sub- divisional, District and State – level committees for monitoring of village relocation process & grievance redressal] and Sub Divisional Level Committee, Child label of [Constituted]  only allow pdf");
                $("#contentbody_FileUpload8_a_a").focus();
                chk = 0;
                return false;
            }

        };
        if ($("#contentbody_FileUpload8_a_a").val() != "") {
            var inputVal = $("#contentbody_FileUpload8_a_a").val();
            //alert(inputVal);
            //var numericReg = /^.*\.(jpg|jpeg|png|gif)$/;
            var numericReg = /^.*\.(pdf)$/;
            if (!numericReg.test(inputVal)) {
                alert("Please enter of Title [8.Sub- divisional, District and State – level committees for monitoring of village relocation process & grievance redressal] and District Level Committee, Child label of [Constituted]  only allow pdf");
                $("#contentbody_FileUpload8_a_a").focus();
                chk = 0;
                return false;
            }

        };
        if ($("#contentbody_FileUpload8_c_a").val() != "") {
            var inputVal = $("#contentbody_FileUpload8_c_a").val();
            //alert(inputVal);
            //var numericReg = /^.*\.(jpg|jpeg|png|gif)$/;
            var numericReg = /^.*\.(pdf)$/;
            if (!numericReg.test(inputVal)) {
                alert("Please enter of Title [8.Sub- divisional, District and State – level committees for monitoring of village relocation process & grievance redressal] and State Level Monitoring Committee, Child label of [Constituted]  only allow pdf");
                $("#contentbody_FileUpload8_c_a").focus();
                chk = 0;
                return false;
            }

        };
        //end 2.Buffer or Peripheral Area
        //end panel 1

        //start panel 2
        //1
        if ($("#contentbody_TextCheckItems1").val() != "") {
            var inputVal = $("#contentbody_TextCheckItems1").val();
            //alert(inputVal);
            var numericReg = /^\s*[a-zA-Z0-9,\s]+\s*$/;
            if (!numericReg.test(inputVal)) {
                alert("Please enter of S.No [1] of label Result for No special characters allowed");
                $("#contentbody_TextCheckItems1").focus();
                chk = 0;
                return false;
            }
        }
        //---------------------------------------------------------------
        if ($("#contentbody_FileUploadCheckItems1").val() != "") {
            var inputVal = $("#contentbody_FileUploadCheckItems1").val();
            //  alert(inputVal);
            //var numericReg = /^.*\.(jpg|jpeg|png|gif)$/;
            var numericReg = /^.*\.(pdf)$/;
            if (!numericReg.test(inputVal)) {
                alert("Please enter of S.No [1] of label Result upload allow only pdf");
                $("#contentbody_FileUploadCheckItems1").focus();
                chk = 0;
                return false;
            }

        };
        //-2---
        if ($("#contentbody_TextCheckItems2").val() != "") {
            var inputVal = $("#contentbody_TextCheckItems2").val();
            //alert(inputVal);
            var numericReg = /^\s*[a-zA-Z0-9,\s]+\s*$/;
            if (!numericReg.test(inputVal)) {
                alert("Please enter of S.No [2] of label Result for No special characters allowed");
                $("#contentbody_TextCheckItems2").focus();
                chk = 0;
                return false;
            }
        }
        if ($("#contentbody_FileUploadCheckItems2").val() != "") {
            var inputVal = $("#contentbody_FileUploadCheckItems2").val();
            //alert(inputVal);
            //var numericReg = /^.*\.(jpg|jpeg|png|gif)$/;
            var numericReg = /^.*\.(pdf)$/;
            if (!numericReg.test(inputVal)) {
                alert("Please enter of S.No [2] of label Result upload allow only pdf");
                $("#contentbody_FileUploadCheckItems2").focus();
                chk = 0;
                return false;
            }

        };
        //--3
        if ($("#contentbody_TextCheckItems3").val() != "") {
            var inputVal = $("#contentbody_TextCheckItems3").val();
            //alert(inputVal);
            var numericReg = /^\s*[a-zA-Z0-9,\s]+\s*$/;
            if (!numericReg.test(inputVal)) {
                alert("Please enter of S.No [3] of label Result for No special characters allowed");
                $("#contentbody_TextCheckItems3").focus();
                chk = 0;
                return false;
            }
        }
        if ($("#contentbody_FileUploadCheckItems3").val() != "") {
            var inputVal = $("#contentbody_FileUploadCheckItems3").val();
            //alert(inputVal);
            //var numericReg = /^.*\.(jpg|jpeg|png|gif)$/;
            var numericReg = /^.*\.(pdf)$/;
            if (!numericReg.test(inputVal)) {
                alert("Please enter of S.No [3] of label Result upload allow only pdf");
                $("#contentbody_FileUploadCheckItems3").focus();
                chk = 0;
                return false;
            }

        };
        //--4
        if ($("#contentbody_TextCheckItems4").val() != "") {
            var inputVal = $("#contentbody_TextCheckItems4").val();
            //alert(inputVal);
            var numericReg = /^\s*[a-zA-Z0-9,\s]+\s*$/;
            if (!numericReg.test(inputVal)) {
                alert("Please enter of S.No [4] of label Result for No special characters allowed");
                $("#contentbody_TextCheckItems4").focus();
                chk = 0;
                return false;
            }
        }
        if ($("#contentbody_FileUploadCheckItems4").val() != "") {
            var inputVal = $("#contentbody_FileUploadCheckItems4").val();
            //alert(inputVal);
            //var numericReg = /^.*\.(jpg|jpeg|png|gif)$/;
            var numericReg = /^.*\.(pdf)$/;
            if (!numericReg.test(inputVal)) {
                alert("Please enter of S.No [4] of label Result upload allow only pdf");
                $("#contentbody_FileUploadCheckItems4").focus();
                chk = 0;
                return false;
            }

        };
        //--5
        if ($("#contentbody_TextCheckItems5").val() != "") {
            var inputVal = $("#contentbody_TextCheckItems5").val();
            //alert(inputVal);
            var numericReg = /^\s*[a-zA-Z0-9,\s]+\s*$/;
            if (!numericReg.test(inputVal)) {
                alert("Please enter of S.No [5] of label Result for No special characters allowed");
                $("#contentbody_TextCheckItems5").focus();
                chk = 0;
                return false;
            }
        }
        if ($("#contentbody_FileUploadCheckItems5").val() != "") {
            var inputVal = $("#contentbody_FileUploadCheckItems5").val();
            //alert(inputVal);
            //var numericReg = /^.*\.(jpg|jpeg|png|gif)$/;
            var numericReg = /^.*\.(pdf)$/;
            if (!numericReg.test(inputVal)) {
                alert("Please enter of S.No [5] of label Result upload allow only pdf");
                $("#contentbody_FileUploadCheckItems5").focus();
                chk = 0;
                return false;
            }

        };
        //---6
        //if ($("#contentbody_TextCheckItems6").val() != "") {
        //    var inputVal = $("#contentbody_TextCheckItems6").val();
        //    //alert(inputVal);
        //    var numericReg = /^\s*[a-zA-Z0-9,\s]+\s*$/;
        //    if (!numericReg.test(inputVal)) {
        //        alert("Please enter of S.No [6] of label Result for No special characters allowed");
        //        $("#contentbody_TextCheckItems6").focus();
        //        chk = 0;
        //        return false;
        //    }
        //}
        if ($("#contentbody_FileUploadCheckItems6").val() != "") {
            var inputVal = $("#contentbody_FileUploadCheckItems6").val();
            //alert(inputVal);
            //var numericReg = /^.*\.(jpg|jpeg|png|gif)$/;
            var numericReg = /^.*\.(pdf)$/;
            if (!numericReg.test(inputVal)) {
                alert("Please enter of S.No [6] of label Result upload allow only pdf");
                $("#contentbody_FileUploadCheckItems6").focus();
                chk = 0;
                return false;
            }

        };
        //--7
        //  alert($("#contentbody_TextCheckItems7").val());
        if ($("#contentbody_TextCheckItems7").val() != "") {
            var inputVal = $("#contentbody_TextCheckItems7").val();
            //alert(inputVal);
            var numericReg = /^\s*[a-zA-Z0-9,\s]+\s*$/;
            if (!numericReg.test(inputVal)) {
                alert("Please enter of S.No [7] of label Result for No special characters allowed");
                $("#contentbody_TextCheckItems7").focus();
                chk = 0;
                return false;
            }
        }
        if ($("#contentbody_FileUploadCheckItems7").val() != "") {
            var inputVal = $("#contentbody_FileUploadCheckItems7").val();
            //alert(inputVal);
            //var numericReg = /^.*\.(jpg|jpeg|png|gif)$/;
            var numericReg = /^.*\.(pdf)$/;
            if (!numericReg.test(inputVal)) {
                alert("Please enter of S.No [7] of label Result upload allow only pdf");
                $("#contentbody_FileUploadCheckItems7").focus();
                chk = 0;
                return false;
            }

        };
        //end panel 2
        //-------end of validation---------------

        if (chk == 1) {

            $(this).parent().next().fadeIn('slow');
            $(this).parent().css({ 'display': 'none' });
            //Adding class active to show steps forward;
            $('.active').next().addClass('active');
        }

        return true;

    });

    $(".pre_btn").click(function () {            //Function runs on PREVIOUS button click 
        $(this).parent().prev().fadeIn('slow');
        $(this).parent().css({ 'display': 'none' });
        //Removing class active to show steps backward;
        $('.active:last').removeClass('active');



    });


});
