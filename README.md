# NoValidRecipientReplicate

Note: ensure that port 50000 is not being used prior to test.

1.  Open "NoValidRecipientReplicate.sln" with VS2015
2.  Build Solution
3.  Set breakpoint on line 20 of "~\NoValidRecipientReplicate\FakeSmtpClient\SmtpRelayClientImp.cs"
4.  Set "ReplicateScenario" as Startup Project
5.  Start without Debugging (CTRL + F5)
6.  Attach to process "SmtpClientApp"
7.  On the "SmtpServerApp" app console, press F1 to proceed
8.  On the "SmtpClientApp" app console, press F1 to proceed.
9.  Hit 'X' to close the "SmtpServerApp" console.  
10. The breakpoint should be hit.
