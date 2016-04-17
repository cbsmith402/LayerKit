using Foundation;
using System;
using ObjCRuntime;

namespace LayerKit
{
	// @interface LYRPredicate : NSObject <NSCopying, NSCoding>
	[BaseType(typeof(NSObject))]
	interface LYRPredicate : INSCopying, INSCoding
	{
		// +(instancetype _Nonnull)predicateWithProperty:(NSString * _Nonnull)property predicateOperator:(LYRPredicateOperator)predicateOperator value:(id _Nullable)value;
		[Static]
		[Export("predicateWithProperty:predicateOperator:value:")]
		LYRPredicate PredicateWithProperty(string property, LYRPredicateOperator predicateOperator, [NullAllowed] NSObject value);

		// @property (readonly, copy, nonatomic) NSString * _Nonnull property;
		[Export("property")]
		string Property { get; }

		// @property (readonly, nonatomic) LYRPredicateOperator predicateOperator;
		[Export("predicateOperator")]
		LYRPredicateOperator PredicateOperator { get; }

		// @property (readonly, nonatomic) id _Nullable value;
		[NullAllowed, Export("value")]
		NSObject Value { get; }
	}

	// @interface LYRCompoundPredicate : LYRPredicate <NSCopying, NSCoding>
	[BaseType(typeof(LYRPredicate))]
	interface LYRCompoundPredicate : INSCopying, INSCoding
	{
		// +(instancetype _Nonnull)compoundPredicateWithType:(LYRCompoundPredicateType)compoundPredicateType subpredicates:(NSArray<__kindof LYRPredicate *> * _Nonnull)subpredicates;
		[Static]
		[Export("compoundPredicateWithType:subpredicates:")]
		LYRCompoundPredicate CompoundPredicateWithType(LYRCompoundPredicateType compoundPredicateType, LYRPredicate[] subpredicates);

		// @property (readonly, nonatomic) LYRCompoundPredicateType compoundPredicateType;
		[Export("compoundPredicateType")]
		LYRCompoundPredicateType CompoundPredicateType { get; }

		// @property (readonly, nonatomic) NSArray * _Nonnull subpredicates;
		[Export("subpredicates")]
		NSObject[] Subpredicates { get; }
	}

	// @protocol LYRQueryable <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface LYRQueryable
	{
		// @required @property (readonly, nonatomic) NSURL * _Nonnull identifier;
		[Export("identifier")]
		NSUrl Identifier { get; }
	}

	[BaseType(typeof(NSObject))]
	interface LYRQuery : INSCopying, INSCoding
	{
		[Static]
		[Export("queryWithQueryableClass:")]
		LYRQuery QueryWithQueryableClass(LYRQueryable queryableClass);

		[Export("queryableClass")]
		LYRQueryable QueryableClass { get; }

		[NullAllowed, Export("predicate", ArgumentSemantic.Assign)]
		LYRPredicate Predicate { get; set; }

		[Export("limit")]
		nuint Limit { get; set; }

		[Export("offset")]
		nuint Offset { get; set; }

		[NullAllowed, Export("sortDescriptors", ArgumentSemantic.Assign)]
		NSSortDescriptor[] SortDescriptors { get; set; }

		[Export("resultType", ArgumentSemantic.Assign)]
		LYRQueryResultType ResultType { get; set; }

	}

	[BaseType(typeof(NSObject))]
	interface LYRConversation : LYRQueryable
	{
		[Export("identifier")]
		NSUrl Identifier { get; }

		[Export("participants")]
		NSSet<LYRIdentity> Participants { get; }

		[Export("createdAt")]
		NSDate CreatedAt { get; }

		[NullAllowed, Export("lastMessage")]
		LYRMessage LastMessage { get; }

		[Export("hasUnreadMessages")]
		bool HasUnreadMessages { get; }

		[Export("isDistinct")]
		bool IsDistinct { get; }

		[Export("isDeleted")]
		bool IsDeleted { get; }

		[Export("deliveryReceiptsEnabled")]
		bool DeliveryReceiptsEnabled { get; }

		[Export("sendMessage:error:")]
		bool SendMessage(LYRMessage message, [NullAllowed] out NSError error);

		[Export("addParticipants:error:")]
		bool AddParticipants(NSSet<NSString> participants, [NullAllowed] out NSError error);

		[Export("removeParticipants:error:")]
		bool RemoveParticipants(NSSet<NSString> participants, [NullAllowed] out NSError error);

		[NullAllowed, Export("metadata")]
		NSDictionary<NSString, NSObject> Metadata { get; }

		[Export("setValue:forMetadataAtKeyPath:")]
		void SetValue([NullAllowed] NSObject value, string keyPath);

		[Export("setValuesForMetadataKeyPathsWithDictionary:merge:")]
		void SetValuesForMetadataKeyPathsWithDictionary(NSDictionary<NSString, NSObject> metadata, bool merge);

		[Export("deleteValueForMetadataAtKeyPath:")]
		void DeleteValueForMetadataAtKeyPath(string keyPath);

		[Export("sendTypingIndicator:")]
		void SendTypingIndicator(LYRTypingIndicator typingIndicator);

		[Export("delete:error:")]
		bool Delete(LYRDeletionMode deletionMode, [NullAllowed] out NSError error);

		[Export("leave:")]
		bool Leave([NullAllowed] out NSError error);

		[Export("markAllMessagesAsRead:")]
		bool MarkAllMessagesAsRead([NullAllowed] out NSError error);

		[Export("totalNumberOfMessages")]
		nuint TotalNumberOfMessages { get; }

		[Export("totalNumberOfUnreadMessages")]
		nuint TotalNumberOfUnreadMessages { get; }

		[Export("synchronizeMoreMessages:error:")]
		bool SynchronizeMoreMessages(nuint minimumNumberOfMessages, [NullAllowed] out NSError error);

		[Export("synchronizeAllMessages:error:")]
		bool SynchronizeAllMessages(LYRMessageSyncOptions messageSyncOption, [NullAllowed] out NSError error);

	}

	[BaseType(typeof(NSObject))]
	interface LYRActor
	{
		[NullAllowed, Export("userID")]
		string UserID { get; }

		[NullAllowed, Export("name")]
		string Name { get; }

	}

	[BaseType(typeof(NSObject))]
	interface LYRPushNotificationConfiguration
	{
		[NullAllowed, Export("alert")]
		string Alert { get; set; }

		[NullAllowed, Export("sound")]
		string Sound { get; set; }

		[NullAllowed, Export("title")]
		string Title { get; set; }

		[NullAllowed, Export("category")]
		string Category { get; set; }

		[NullAllowed, Export("apns", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSString> Apns { get; set; }

		[NullAllowed, Export("data", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSString> Data { get; set; }

		[NullAllowed, Export("titleLocalizationKey")]
		string TitleLocalizationKey { get; set; }

		[NullAllowed, Export("titleLocalizationArguments", ArgumentSemantic.Copy)]
		string[] TitleLocalizationArguments { get; set; }

		[NullAllowed, Export("alertLocalizationKey")]
		string AlertLocalizationKey { get; set; }

		[NullAllowed, Export("alertLocalizationArguments", ArgumentSemantic.Copy)]
		string[] AlertLocalizationArguments { get; set; }

		[NullAllowed, Export("actionLocalizationKey")]
		string ActionLocalizationKey { get; set; }

		[Export("setPushConfiguration:forParticipant:")]
		void SetPushConfiguration(LYRPushNotificationConfiguration configuration, string participantIdentifier);

	}

	[BaseType(typeof(NSObject))]
	interface LYRIdentity : LYRQueryable, ObjCRuntime.INativeObject
	{
		[Export("identifier")]
		NSUrl Identifier { get; }

		[Export("userID")]
		string UserID { get; }

		[Export("displayName")]
		string DisplayName { get; }

		[Export("firstName")]
		string FirstName { get; }

		[Export("lastName")]
		string LastName { get; }

		[Export("emailAddress")]
		string EmailAddress { get; }

		[Export("phoneNumber")]
		string PhoneNumber { get; }

		[Export("avatarImageURL")]
		NSUrl AvatarImageURL { get; }

		[Export("metadata")]
		NSDictionary Metadata { get; }

		[Export("publicKey")]
		string PublicKey { get; }

		[Export("followed")]
		bool Followed { get; }

	}

	[BaseType(typeof(NSObject))]
	interface LYRMessage : LYRQueryable, ObjCRuntime.INativeObject
	{
		[Export("identifier")]
		NSUrl Identifier { get; }

		[Export("position")]
		long Position { get; }

		[Export("conversation")]
		LYRConversation Conversation { get; }

		[Export("parts")]
		LYRMessagePart[] Parts { get; }

		[Export("isSent")]
		bool IsSent { get; }

		[Export("isDeleted")]
		bool IsDeleted { get; }

		[Export("isUnread")]
		bool IsUnread { get; }

		[NullAllowed, Export("sentAt")]
		NSDate SentAt { get; }

		[NullAllowed, Export("receivedAt")]
		NSDate ReceivedAt { get; }

		[Export("sender")]
		LYRIdentity Sender { get; }

		[Export("markAsRead:")]
		bool MarkAsRead([NullAllowed] out NSError error);

		[Export("delete:error:")]
		bool Delete(LYRDeletionMode deletionMode, [NullAllowed] out NSError error);

		[NullAllowed, Export("recipientStatusByUserID")]
		NSDictionary<NSString, NSNumber> RecipientStatusByUserID { get; }

		[Export("recipientStatusForUserID:")]
		LYRRecipientStatus RecipientStatusForUserID(string userID);

	}

	[BaseType(typeof(NSObject))]
	interface LYRProgress
	{
		[Export("totalUnitCount")]
		nuint TotalUnitCount { get; }

		[Export("completedUnitCount")]
		nuint CompletedUnitCount { get; }

		[Export("fractionCompleted")]
		double FractionCompleted { get; }

		[NullAllowed, Export("userInfo", ArgumentSemantic.Copy)]
		NSDictionary UserInfo { get; set; }

		[Wrap("WeakDelegate")]
		[NullAllowed]
		LYRProgressDelegate Delegate { get; set; }

		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		[Export("cancellable")]
		bool Cancellable { [Bind ("isCancellable")] get; }

		[Export("cancelled")]
		bool Cancelled { [Bind ("isCancelled")] get; }

		[Export("cancel")]
		void Cancel();

		[Export("pausable")]
		bool Pausable { [Bind ("isPausable")] get; }

		[Export("paused")]
		bool Paused { [Bind ("isPaused")] get; }

		[Export("pause")]
		void Pause();

	}

	[BaseType(typeof(LYRProgress))]
	interface LYRAggregateProgress
	{
		[NullAllowed, Export("children")]
		LYRProgress[] Children { get; }

		[Static]
		[Export("aggregateProgressWithProgresses:")]
		LYRAggregateProgress AggregateProgressWithProgresses([NullAllowed] NSObject[] progresses);

		[Export("addProgress:")]
		void AddProgress(LYRProgress progress);

	}

	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface LYRProgressDelegate
	{
		[Abstract]
		[Export("progressDidChange:")]
		void ProgressDidChange(LYRProgress progress);

	}

	[BaseType(typeof(NSObject))]
	interface LYRMessagePart : LYRQueryable
	{
		[Static]
		[Export("messagePartWithMIMEType:data:")]
		LYRMessagePart MessagePartWithMIMEType(string MIMEType, NSData data);

		[Static]
		[Export("messagePartWithMIMEType:stream:")]
		LYRMessagePart MessagePartWithMIMEType(string MIMEType, NSInputStream stream);

		[Static]
		[Export("messagePartWithText:")]
		LYRMessagePart MessagePartWithText(string text);

		[Export("identifier")]
		NSUrl Identifier { get; }

		[Export("index")]
		nuint Index { get; }

		[NullAllowed, Export("message")]
		LYRMessage Message { get; }

		[Export("MIMEType")]
		string MIMEType { get; }

		[NullAllowed, Export("data")]
		NSData Data { get; }

		[NullAllowed, Export("fileURL")]
		NSUrl FileURL { get; }

		[Export("size")]
		ulong Size { get; }

		[Export("transferStatus")]
		LYRContentTransferStatus TransferStatus { get; }

		[Export("progress")]
		LYRProgress Progress { get; }

		[NullAllowed, Export("inputStream")]
		NSInputStream InputStream { get; }

		[Export("downloadContent:")]
		[return: NullAllowed]
		LYRProgress DownloadContent([NullAllowed] out NSError error);

		[Export("purgeContent:")]
		[return: NullAllowed]
		LYRProgress PurgeContent([NullAllowed] out NSError error);

	}

	[BaseType(typeof(LYRMessage))]
	interface LYRAnnouncement
	{

	}

	[BaseType(typeof(NSObject))]
	interface LYRPolicy : INSCopying, INSCoding
	{
		[Static]
		[Export("policyWithType:")]
		LYRPolicy PolicyWithType(LYRPolicyType type);

		[Export("type")]
		LYRPolicyType Type { get; }

		[NullAllowed, Export("sentByUserID")]
		string SentByUserID { get; set; }

	}

	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface LYRClientDelegate
	{
		[Abstract]
		[Export("layerClient:didReceiveAuthenticationChallengeWithNonce:")]
		void LayerClient(LYRClient client, string nonce);

		[Export("layerClient:willAttemptToConnect:afterDelay:maximumNumberOfAttempts:")]
		void LayerClient(LYRClient client, nuint attemptNumber, double delayInterval, nuint attemptLimit);

		[Export("layerClientDidConnect:")]
		void LayerClientDidConnect(LYRClient client);

		[Export("layerClient:didLoseConnectionWithError:")]
		void LayerClient(LYRClient client, NSError error);

		[Export("layerClientDidDisconnect:")]
		void LayerClientDidDisconnect(LYRClient client);

		[Export("layerClient:didAuthenticateAsUserID:")]
		void LayerClientDidAuthenticateAsUserID(LYRClient client, string userID);

		[Export("layerClientDidDeauthenticate:")]
		void LayerClientDidDeauthenticate(LYRClient client);

		[Export("layerClient:objectsDidChange:")]
		void LayerClient(LYRClient client, LYRObjectChange[] changes);

		[Export("layerClient:didFailOperationWithError:")]
		void LayerClientDidFailOperationWithError(LYRClient client, NSError error);

		[Export("layerClient:willBeginContentTransfer:ofObject:withProgress:")]
		void LayerClient(LYRClient client, LYRContentTransferType contentTransferType, NSObject @object, LYRProgress progress);

		[Export("layerClient:didFinishContentTransfer:ofObject:")]
		void LayerClient(LYRClient client, LYRContentTransferType contentTransferType, NSObject @object);

	}

	[BaseType(typeof(NSObject))]
	interface LYRClient
	{
		[Static]
		[Export("clientWithAppID:options:")]
		[return: NullAllowed]
		LYRClient ClientWithAppID(NSUrl appID, [NullAllowed] NSDictionary options);

		[Wrap("WeakDelegate")]
		[NullAllowed]
		LYRClientDelegate Delegate { get; set; }

		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		[Export("appID", ArgumentSemantic.Copy)]
		NSUrl AppID { get; }

		[Export("connectWithCompletion:")]
		void ConnectWithCompletion([NullAllowed] Action<bool, NSError> completion);

		[Export("disconnect")]
		void Disconnect();

		[Export("isConnecting")]
		bool IsConnecting { get; }

		[Export("isConnected")]
		bool IsConnected { get; }

		[NullAllowed, Export("authenticatedUser")]
		LYRIdentity AuthenticatedUser { get; }

		[Export("requestAuthenticationNonceWithCompletion:")]
		void RequestAuthenticationNonceWithCompletion(Action<NSString, NSError> completion);

		[Export("authenticateWithIdentityToken:completion:")]
		void AuthenticateWithIdentityToken(string identityToken, Action<LYRIdentity, NSError> completion);

		[Export("deauthenticateWithCompletion:")]
		void DeauthenticateWithCompletion([NullAllowed] Action<bool, NSError> completion);

		[Export("updateRemoteNotificationDeviceToken:error:")]
		bool UpdateRemoteNotificationDeviceToken([NullAllowed] NSData deviceToken, [NullAllowed] out NSError error);

		[Export("synchronizeWithRemoteNotification:completion:")]
		bool SynchronizeWithRemoteNotification(NSDictionary userInfo, Action<LYRConversation, LYRMessage, NSError> completion);

		[Export("newConversationWithParticipants:options:error:")]
		[return: NullAllowed]
		LYRConversation NewConversationWithParticipants(NSSet<NSString> participants, [NullAllowed] NSDictionary<NSString, NSObject> options, [NullAllowed] out NSError error);

		[Export("newMessageWithParts:options:error:")]
		[return: NullAllowed]
		LYRMessage NewMessageWithParts(LYRMessagePart[] messageParts, [NullAllowed] NSDictionary<NSString, NSObject> options, [NullAllowed] out NSError error);

		[Export("executeQuery:error:")]
		[return: NullAllowed]
		NSOrderedSet ExecuteQuery(LYRQuery query, [NullAllowed] out NSError error);

		[Export("executeQuery:completion:")]
		void ExecuteQuery(LYRQuery query, Action<NSOrderedSet, NSError> completion);

		[Export("countForQuery:error:")]
		nuint CountForQuery(LYRQuery query, [NullAllowed] out NSError error);

		[Export("countForQuery:completion:")]
		void CountForQuery(LYRQuery query, Action<nuint, NSError> completion);

		[Export("queryControllerWithQuery:error:")]
		[return: NullAllowed]
		LYRQueryController QueryControllerWithQuery(LYRQuery query, [NullAllowed] out NSError error);

		[Export("markMessagesAsRead:error:")]
		bool MarkMessagesAsRead(NSSet<LYRMessage> messages, [NullAllowed] out NSError error);

		[Export("followUserIDs:error:")]
		bool FollowUserIDs(NSSet<NSString> userIDs, [NullAllowed] out NSError error);

		[Export("unfollowUserIDs:error:")]
		bool UnfollowUserIDs(NSSet<NSString> userIDs, [NullAllowed] out NSError error);

		[NullAllowed, Export("policies")]
		NSOrderedSet Policies { get; }

		[Export("validatePolicy:error:")]
		bool ValidatePolicy(LYRPolicy policy, [NullAllowed] out NSError error);

		[Export("addPolicy:error:")]
		bool AddPolicy(LYRPolicy policy, [NullAllowed] out NSError error);

		[Export("insertPolicy:atIndex:error:")]
		bool InsertPolicy(LYRPolicy policy, nuint index, [NullAllowed] out NSError error);

		[Export("removePolicy:error:")]
		bool RemovePolicy(LYRPolicy policy, [NullAllowed] out NSError error);

		[Export("diskCapacity")]
		ulong DiskCapacity { get; set; }

		[Export("currentDiskUtilization")]
		ulong CurrentDiskUtilization { get; }

		[Export("backgroundContentTransferEnabled")]
		bool BackgroundContentTransferEnabled { get; set; }

		[Export("handleBackgroundContentTransfersForSession:completion:")]
		bool HandleBackgroundContentTransfersForSession(string sessionIdentifier, Action<NSArray, NSError> completion);

		[NullAllowed, Export("autodownloadMIMETypes", ArgumentSemantic.Assign)]
		NSSet<NSString> AutodownloadMIMETypes { get; set; }

		[Export("autodownloadMaximumContentSize")]
		ulong AutodownloadMaximumContentSize { get; set; }

		[Export("synchronizationPolicy")]
		LYRClientSynchronizationPolicy SynchronizationPolicy { get; }

		[Export("synchronizationPolicyOptions")]
		NSDictionary SynchronizationPolicyOptions { get; }

		[Export("waitForCreationOfObjectWithIdentifier:timeout:completion:")]
		void WaitForCreationOfObjectWithIdentifier(NSUrl objectIdentifier, double timeout, Action<NSObject, NSError> completion);

		[Export("captureDebugSnapshotWithCompletion:")]
		void CaptureDebugSnapshotWithCompletion(Action<NSUrl, NSError> completion);

		[Export("debuggingEnabled")]
		bool DebuggingEnabled { get; set; }

		[Export("setLogLevel:forComponent:")]
		void SetLogLevel(LYRLogLevel level, LYRLogComponent component);

	}

	[BaseType(typeof(NSObject))]
	interface LYRObjectChange
	{
		[Export("object")]
		NSObject Object { get; }

		[Export("type")]
		LYRObjectChangeType Type { get; }

		[NullAllowed, Export("property")]
		string Property { get; }

		[NullAllowed, Export("beforeValue")]
		NSObject BeforeValue { get; }

		[NullAllowed, Export("afterValue")]
		NSObject AfterValue { get; }

	}

	[BaseType(typeof(NSObject))]
	interface LYRQueryController
	{
		[Export("query")]
		LYRQuery Query { get; }

		[NullAllowed, Export("updatableProperties", ArgumentSemantic.Assign)]
		NSSet<NSString> UpdatableProperties { get; set; }

		[Export("paginationWindow")]
		nint PaginationWindow { get; set; }

		[Export("totalNumberOfObjects")]
		nuint TotalNumberOfObjects { get; }

		[Wrap("WeakDelegate")]
		[NullAllowed]
		LYRQueryControllerDelegate Delegate { get; set; }

		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		[Export("numberOfSections")]
		nuint NumberOfSections { get; }

		[Export("numberOfObjectsInSection:")]
		nuint NumberOfObjectsInSection(nuint section);

		[Export("count")]
		nuint Count { get; }

		[Export("objectAtIndexPath:")]
		[return: NullAllowed]
		NSObject ObjectAtIndexPath(NSIndexPath indexPath);

		[Export("indexPathForObject:")]
		[return: NullAllowed]
		NSIndexPath IndexPathForObject(LYRQueryable @object);

		[Export("indexPathsForObjectsWithIdentifiers:")]
		NSDictionary IndexPathsForObjectsWithIdentifiers(NSSet objectIdentifiers);

		[Export("execute:")]
		bool Execute([NullAllowed] out NSError error);

		[Export("executeWithCompletion:")]
		void ExecuteWithCompletion(Action<bool, NSError> completion);

	}

	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface LYRQueryControllerDelegate
	{
		[Export("queryControllerWillChangeContent:")]
		void QueryControllerWillChangeContent(LYRQueryController queryController);

		[Export("queryControllerDidChangeContent:")]
		void QueryControllerDidChangeContent(LYRQueryController queryController);

		[Export("queryController:didChangeObject:atIndexPath:forChangeType:newIndexPath:")]
		void QueryController(LYRQueryController controller, NSObject @object, [NullAllowed] NSIndexPath indexPath, LYRQueryControllerChangeType type, [NullAllowed] NSIndexPath newIndexPath);

	}

	/*
[Static]
[Verify (ConstantsInterfaceAssociation)]
partial interface Constants
{
	// extern NSString *const _Nonnull LYRQueryingErrorDomain;
	[Field ("LYRQueryingErrorDomain", "__Internal")]
	NSString LYRQueryingErrorDomain { get; }
}

[Static]
[Verify (ConstantsInterfaceAssociation)]
partial interface Constants
{
	// extern NSString *const _Nonnull LYRConversationOptionsMetadataKey;
	[Field ("LYRConversationOptionsMetadataKey", "__Internal")]
	NSString LYRConversationOptionsMetadataKey { get; }

	// extern NSString *const _Nonnull LYRConversationOptionsDeliveryReceiptsEnabledKey;
	[Field ("LYRConversationOptionsDeliveryReceiptsEnabledKey", "__Internal")]
	NSString LYRConversationOptionsDeliveryReceiptsEnabledKey { get; }

	// extern NSString *const _Nonnull LYRConversationOptionsDistinctByParticipantsKey;
	[Field ("LYRConversationOptionsDistinctByParticipantsKey", "__Internal")]
	NSString LYRConversationOptionsDistinctByParticipantsKey { get; }

	// extern NSString *const _Nonnull LYRConversationDidReceiveTypingIndicatorNotification;
	[Field ("LYRConversationDidReceiveTypingIndicatorNotification", "__Internal")]
	NSString LYRConversationDidReceiveTypingIndicatorNotification { get; }

	// extern NSString *const _Nonnull LYRTypingIndicatorValueUserInfoKey;
	[Field ("LYRTypingIndicatorValueUserInfoKey", "__Internal")]
	NSString LYRTypingIndicatorValueUserInfoKey { get; }

	// extern NSString *const _Nonnull LYRTypingIndicatorParticipantUserInfoKey;
	[Field ("LYRTypingIndicatorParticipantUserInfoKey", "__Internal")]
	NSString LYRTypingIndicatorParticipantUserInfoKey { get; }

	// extern NSString *const _Nonnull LYRConversationWillBeginSynchronizingNotification;
	[Field ("LYRConversationWillBeginSynchronizingNotification", "__Internal")]
	NSString LYRConversationWillBeginSynchronizingNotification { get; }

	// extern NSString *const _Nonnull LYRConversationDidFinishSynchronizingNotification;
	[Field ("LYRConversationDidFinishSynchronizingNotification", "__Internal")]
	NSString LYRConversationDidFinishSynchronizingNotification { get; }

	// extern NSString *const _Nonnull LYRConversationSynchronizationProgressUserInfoKey;
	[Field ("LYRConversationSynchronizationProgressUserInfoKey", "__Internal")]
	NSString LYRConversationSynchronizationProgressUserInfoKey { get; }
}

[Static]
[Verify (ConstantsInterfaceAssociation)]
partial interface Constants
{
	// extern NSString *const _Nonnull LYRMessageOptionsPushNotificationConfigurationKey;
	[Field ("LYRMessageOptionsPushNotificationConfigurationKey", "__Internal")]
	NSString LYRMessageOptionsPushNotificationConfigurationKey { get; }
}

[Static]
[Verify (ConstantsInterfaceAssociation)]
partial interface Constants
{
	// extern NSString *const _Nonnull LYRClientDidAuthenticateNotification;
	[Field ("LYRClientDidAuthenticateNotification", "__Internal")]
	NSString LYRClientDidAuthenticateNotification { get; }

	// extern NSString *const _Nonnull LYRClientAuthenticatedUserIDUserInfoKey;
	[Field ("LYRClientAuthenticatedUserIDUserInfoKey", "__Internal")]
	NSString LYRClientAuthenticatedUserIDUserInfoKey { get; }

	// extern NSString *const _Nonnull LYRClientDidDeauthenticateNotification;
	[Field ("LYRClientDidDeauthenticateNotification", "__Internal")]
	NSString LYRClientDidDeauthenticateNotification { get; }

	// extern NSString *const _Nonnull LYRClientWillBeginSynchronizationNotification;
	[Field ("LYRClientWillBeginSynchronizationNotification", "__Internal")]
	NSString LYRClientWillBeginSynchronizationNotification { get; }

	// extern NSString *const _Nonnull LYRClientDidFinishSynchronizationNotification;
	[Field ("LYRClientDidFinishSynchronizationNotification", "__Internal")]
	NSString LYRClientDidFinishSynchronizationNotification { get; }

	// extern NSString *const _Nonnull LYRClientObjectsDidChangeNotification;
	[Field ("LYRClientObjectsDidChangeNotification", "__Internal")]
	NSString LYRClientObjectsDidChangeNotification { get; }

	// extern NSString *const _Nonnull LYRClientObjectChangesUserInfoKey;
	[Field ("LYRClientObjectChangesUserInfoKey", "__Internal")]
	NSString LYRClientObjectChangesUserInfoKey { get; }

	// extern NSString *const _Nonnull LYRClientWillAttemptToConnectNotification;
	[Field ("LYRClientWillAttemptToConnectNotification", "__Internal")]
	NSString LYRClientWillAttemptToConnectNotification { get; }

	// extern NSString *const _Nonnull LYRClientDidConnectNotification;
	[Field ("LYRClientDidConnectNotification", "__Internal")]
	NSString LYRClientDidConnectNotification { get; }

	// extern NSString *const _Nonnull LYRClientDidLoseConnectionNotification;
	[Field ("LYRClientDidLoseConnectionNotification", "__Internal")]
	NSString LYRClientDidLoseConnectionNotification { get; }

	// extern NSString *const _Nonnull LYRClientDidDisconnectNotification;
	[Field ("LYRClientDidDisconnectNotification", "__Internal")]
	NSString LYRClientDidDisconnectNotification { get; }

	// extern NSString *const _Nonnull LYRClientSynchronizationProgressUserInfoKey;
	[Field ("LYRClientSynchronizationProgressUserInfoKey", "__Internal")]
	NSString LYRClientSynchronizationProgressUserInfoKey { get; }

	// extern NSString *const _Nonnull LYRClientOperationErrorUserInfoKey;
	[Field ("LYRClientOperationErrorUserInfoKey", "__Internal")]
	NSString LYRClientOperationErrorUserInfoKey { get; }

	// extern NSString *const _Nonnull LYRClientWillBeginContentTransferNotification;
	[Field ("LYRClientWillBeginContentTransferNotification", "__Internal")]
	NSString LYRClientWillBeginContentTransferNotification { get; }

	// extern NSString *const _Nonnull LYRClientDidFinishContentTransferNotification;
	[Field ("LYRClientDidFinishContentTransferNotification", "__Internal")]
	NSString LYRClientDidFinishContentTransferNotification { get; }

	// extern NSString *const _Nonnull LYRClientContentTransferTypeUserInfoKey;
	[Field ("LYRClientContentTransferTypeUserInfoKey", "__Internal")]
	NSString LYRClientContentTransferTypeUserInfoKey { get; }

	// extern NSString *const _Nonnull LYRClientContentTransferObjectUserInfoKey;
	[Field ("LYRClientContentTransferObjectUserInfoKey", "__Internal")]
	NSString LYRClientContentTransferObjectUserInfoKey { get; }

	// extern NSString *const _Nonnull LYRClientContentTransferProgressUserInfoKey;
	[Field ("LYRClientContentTransferProgressUserInfoKey", "__Internal")]
	NSString LYRClientContentTransferProgressUserInfoKey { get; }

	// extern NSString *const _Nonnull LYRClientOptionSynchronizationPolicy;
	[Field ("LYRClientOptionSynchronizationPolicy", "__Internal")]
	NSString LYRClientOptionSynchronizationPolicy { get; }

	// extern NSString *const _Nonnull LYRClientOptionSynchronizationMessageCount;
	[Field ("LYRClientOptionSynchronizationMessageCount", "__Internal")]
	NSString LYRClientOptionSynchronizationMessageCount { get; }

	// extern NSString *const _Nonnull LYRErrorDomain;
	[Field ("LYRErrorDomain", "__Internal")]
	NSString LYRErrorDomain { get; }
}

[Static]
[Verify (ConstantsInterfaceAssociation)]
partial interface Constants
{
	// extern NSString *const _Nonnull LYRErrorAuthenticatedUserIDUserInfoKey;
	[Field ("LYRErrorAuthenticatedUserIDUserInfoKey", "__Internal")]
	NSString LYRErrorAuthenticatedUserIDUserInfoKey { get; }

	// extern NSString *const _Nonnull LYRErrorUnderlyingErrorsKey;
	[Field ("LYRErrorUnderlyingErrorsKey", "__Internal")]
	NSString LYRErrorUnderlyingErrorsKey { get; }

	// extern NSString *const _Nonnull LYRExistingDistinctConversationKey;
	[Field ("LYRExistingDistinctConversationKey", "__Internal")]
	NSString LYRExistingDistinctConversationKey { get; }

	// extern NSString *const _Nonnull LYRExistingSynchronizationProgress;
	[Field ("LYRExistingSynchronizationProgress", "__Internal")]
	NSString LYRExistingSynchronizationProgress { get; }
}

[Static]
[Verify (ConstantsInterfaceAssociation)]
partial interface Constants
{
	// extern NSString *const LYRSDKVersionString;
	[Field ("LYRSDKVersionString", "__Internal")]
	NSString LYRSDKVersionString { get; }

	// extern double LayerKitVersionNumber;
	[Field ("LayerKitVersionNumber", "__Internal")]
	double LayerKitVersionNumber { get; }

	// extern const unsigned char [] LayerKitVersionString;
	[Field ("LayerKitVersionString", "__Internal")]
	byte[] LayerKitVersionString { get; }
}
*/
}
