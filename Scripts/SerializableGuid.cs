using System;
using UnityEngine;

namespace NodeEditor
{
	/// <summary>
    /// A serialization wrapper for system GUID.
    /// </summary>
	[Serializable]
	public class SerializableGuid : ISerializationCallbackReceiver
	{
		public SerializableGuid()
		{
			m_Guid = Guid.NewGuid();
		}

		public SerializableGuid(Guid guid)
		{
			m_Guid = guid;
		}

		[NonSerialized]
		private Guid m_Guid;

		[SerializeField]
		private string m_GuidSerialized;

		public Guid guid => m_Guid;

		public virtual void OnBeforeSerialize()
		{
			m_GuidSerialized = m_Guid.ToString();
		}

		public virtual void OnAfterDeserialize()
		{
			if (!string.IsNullOrEmpty(m_GuidSerialized))
				m_Guid = new Guid(m_GuidSerialized);
			else
				m_Guid = Guid.NewGuid();
		}
	}
}