using System;
using ObjCRuntime;

namespace LayerKit
{
	[Native]
	public enum LYRPredicateOperator : ulong
	{
		IsEqualTo,
		IsNotEqualTo,
		IsLessThan,
		IsLessThanOrEqualTo,
		IsGreaterThan,
		IsGreaterThanOrEqualTo,
		IsIn,
		IsNotIn,
		Like
	}

	[Native]
	public enum LYRCompoundPredicateType : ulong
	{
		And,
		Or,
		Not
	}

	[Native]
	public enum LYRQueryError : ulong
	{
		queryableProperty = 12000,
		supportedPredicate = 12001,
		supportedSortDescriptor = 12002
	}

	[Native]
	public enum LYRQueryResultType : ulong
	{
		Objects,
		Identifiers,
		Count
	}

	[Native]
	public enum LYRDeletionMode : ulong
	{
		MyDevices = 1,
		AllParticipants = 2
	}

	[Native]
	public enum LYRObjectChangeType : long
	{
		Create = 0,
		Update = 1,
		Delete = 2
	}

	[Native]
	public enum LYRTypingIndicator : ulong
	{
		Begin = 0,
		Pause = 1,
		Finish = 2
	}

	[Native]
	public enum LYRContentTransferType : long
	{
		Download = 0,
		Upload = 1
	}

	[Native]
	public enum LYRClientSynchronizationPolicy : ulong
	{
		CompleteHistory,
		UnreadOnly,
		MessageCount
	}

	[Native]
	public enum LYRMessageSyncOptions : ulong
	{
		All,
		ToFirstUnread
	}

	[Native]
	public enum LYRLogComponent : ulong
	{
		Undefined,
		Initialization,
		Certification,
		Authentication,
		Transport,
		TransportPush,
		PlatformPush,
		Model,
		SQLite,
		Synchronization,
		InboundReconciliation,
		OutboundReconciliation,
		MessagingPublicAPI,
		RichContent,
		ApplicationState,
		Count
	}

	[Native]
	public enum LYRLogLevel : ulong
	{
		Off,
		Error,
		Warn,
		Info,
		Debug,
		Verbose
	}

	[Native]
	public enum LYRRecipientStatus : long
	{
		Invalid = -1,
		Pending = 0,
		Sent = 1,
		Delivered = 2,
		Read = 3
	}

	[Native]
	public enum LYRContentTransferStatus : ulong
	{
		AwaitingUpload,
		Uploading,
		ReadyForDownload,
		Downloading,
		Complete
	}

	[Native]
	public enum LYRPolicyType : long
	{
		LYRPolicyTypeBlock
	}

	[Native]
	public enum LYRError : ulong
	{
		UnknownError = 1000,
		Unauthenticated = 1001,
		InvalidMessage = 1002,
		TooManyParticipants = 1003,
		DataLengthExceedsMaximum = 1004,
		MessageAlreadyMarkedAsRead = 1005,
		ObjectNotSent = 1006,
		MessagePartContentAlreadyAvailable = 1007,
		MessagePartContentAlreadyPurged = 1008,
		MessagePartContentInlined = 1009,
		ConversationAlreadyDeleted = 1010,
		UserNotAParticipantInConversation = 1011,
		ImmutableParticipantsList = 1012,
		DistinctConversationExists = 1013,
		ParticipantNotAParticipantInConversation = 1014,
		DistinctDeletedConversationExists = 1015,
		ParticipantsContainsBlockedUser = 1016,
		InvalidKey = 2000,
		InvalidValue = 2001,
		PolicyValidationFailure = 4000,
		PolicyNotFound = 4001,
		QueryControllerExecutionFailure = 5000
	}

	[Native]
	public enum LYRClientError : ulong
	{
		AlreadyConnected = 6000,
		InvalidAppID = 6001,
		NetworkRequestFailed = 6002,
		ConnectionTimeout = 6003,
		AsyncTimeout = 6004,
		InvalidIdentifier = 6005,
		KeyPairNotFound = 7000,
		CertificateNotFound = 7001,
		IdentityNotFound = 7002,
		NotAuthenticated = 7004,
		AlreadyAuthenticated = 7005,
		DeviceTokenInvalid = 8000,
		UndefinedSyncFailure = 9000,
		DevicePersistenceFailure = 9001,
		SynchronizationFailure = 9002,
		ManualSyncIgnoredInForeground = 9003,
		ManualSyncFailedNoConnection = 9004,
		ManualSyncIgnoredAlreadyInProgress = 9005,
		ManualSyncIgnoredAlreadyFullySynced = 9006,
		ManualSyncIgnoredNothingToSync = 9007,
		ZipArchiveCreationFailure = 10001,
		ZipFileArchiveFailure = 10002,
		TempFileArchiveFailure = 10003,
		SnapshotCaptureFailure = 10004,
		NoFileLoggerPath = 10005,
		DatabaseBackupFailure = 10006,
		MessageDeleted = 11001,
		ConversationDeleted = 11002,
		InvalidClassType = 11003
	}

	[Native]
	public enum LYRQueryControllerChangeType : ulong
	{
		Insert = 1,
		Delete = 2,
		Move = 3,
		Update = 4
	}
}
