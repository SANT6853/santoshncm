<%@ Page Language="C#" AutoEventWireup="true" CodeFile="notes.aspx.cs" Inherits="Notes_notes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div>Fund module table structure</div>
        

select * from TblFromDfoToReserve order by 1 asc --description(from reserve to state)Procedure:spFromDfoToReserve<br />
--truncate table TblFromDfoToReserve<br />
select * from TblFromReserveToDfo order by 1 asc  --description(From state to Reserve)--stateProcedure:spFromDfoToReserve<br />
--<br />
--select * from TblRequestAmountStatus <br />
--truncate table TblFromReserveToDfo<br />
--select * from Mst_Users<br />


select * from TblFromReserveToState --description(From state to Ntca)--stateProcedure:spFromToReserveToState<br />
--truncate table TblFromReserveToState<br />
select * from TblFromStateToReserve --description(From Ntca to state)Procedure:spFromToReserveToState<br />
--truncate table TblFromStateToReserve<br />

--ForwardToStateUserID,ForwardToStateUserName<br />
ForwardToStateUserID meaning ForwardToNtcaUserID<br />
ForwardToStateUserName meaning ForwardToNtcaName<br />
        --aspx page naming wrong<br />
        RequestToStateUser.apx meaning RequestToNtcaUser.aspx<br />
        ReplyFromReserveToDfo meaning ReplyToStateToReserve<br />
        ReserveHistory.aspx meaning HistoryOfStatToReserve<br />
        ViewProcessReserve.aspx meaning Conversation with state to reserve<br />


    </div>
    </form>
</body>
</html>
